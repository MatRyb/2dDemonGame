using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] clips;

    [SerializeField] Transform pivot;
    [SerializeField] Transform charModel;

    private Vector3 characterVelVector = Vector3.zero;
    private Vector3 characterRotationVector = Vector3.zero;

    [SerializeField]
    [Range(0, 5)]
    private float characterVel = 0.1f;

    [SerializeField]
    [Range(0, 5)]
    private float characterRotation = 1.0f;

    [SerializeField]
    [Range(0.1f, 2.0f)]
    private float characterSlowDown = 0.5f;

    private float smooth = 0.01f;
    private float characterVelSpeedUpAfterTurningMovement = 0.003f;

    public bool rotations;
    public bool movable;
    public bool slowed;

    // Jump Variables

    float progress = 0f;
    float jumpTime = 0.5f;

    public bool jumping = false;

    private Vector3 startSize;
    private Vector3 maxSize;

    // End of Jump Variables

    public void SetVel(float value) 
    { 
        characterVel = value; 
    }

    public float GetVel()
    {
        return characterVel;
    }
    public void SetRot(float value)
    {
        characterRotation = value;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterVelVector.x = characterVel;
        pivot = GetComponent<Transform>();
        rotations = false;
        movable = true;

        foreach(Transform child in transform)
        {
            if(child.tag == "PlayerModel")
            {
                charModel = child;
            }
        }

        startSize = charModel.localScale;

        maxSize = new Vector3
            (startSize.x + 0.5f,
            startSize.y + 0.5f,
            startSize.z + 0.5f);
    }

    // Set up custom Methods to fit in the "movable" if statement
    private void FixedUpdate()
    {
        if (movable)
        {
            RotateUpdate();
        }
    }

    private void Update()
    {
        if (movable)
        {
            MovementUpdater();
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            jumping = true;
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        CapsuleCollider capCol = GetComponentInChildren<CapsuleCollider>();

        capCol.enabled = false;

        progress = 0f;

        do
        {
            charModel.localScale = Vector3.Lerp(startSize, maxSize, progress / jumpTime);
            progress += Time.deltaTime;
            yield return null;
        }
        while (progress < jumpTime);

        yield return new WaitForSeconds(0.5f);

        progress = 0f;

        do
        {
            charModel.localScale = Vector3.Lerp(maxSize, startSize, progress / jumpTime);
            progress += Time.deltaTime;
            yield return null;
        }
        while (progress < jumpTime);

        capCol.enabled = true;

        jumping = false;

    }


    // Custom Movement and Rotation methods.
    private void MovementUpdater()
    {
        if (characterVel < characterVelVector.x || !slowed)
        {
            characterVelVector.x = characterVel;
        }
        else if (slowed)
        {
            characterVelVector.x = characterVel * 0.75f;
            Debug.Log("Slowing down");
        }

        

        rotations = false;
        if (Input.GetKey(KeyCode.A))
        {
            characterRotationVector.y = -characterRotation;
            rotations = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterRotationVector.y = characterRotation;
            rotations = true;
        }
    }

    private void RotateUpdate()
    {
        if (rotations)
        { 
            if (characterVelVector.x > characterVel * characterSlowDown)
            {
                characterVelVector.x = characterVelVector.x * 0.99f;
            }
            pivot.transform.Translate(characterVelVector);
        }
        else
        {
            if (characterVelVector.x < characterVel)
            {
                characterVelVector.x += characterVelSpeedUpAfterTurningMovement;
                pivot.transform.Translate(characterVelVector);
            }
            else
            {
                pivot.transform.Translate(characterVelVector * 1.0f);
            }

        }

        pivot.transform.Rotate(characterRotationVector);
        if (characterRotationVector.y != 0 && !rotations)
        {
            characterRotationVector.y *= smooth;
        }
    }
}
