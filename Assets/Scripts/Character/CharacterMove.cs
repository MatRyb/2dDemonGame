using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] clips;

    [SerializeField] Transform pivot;

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
    }







    // Custom Movement and Rotation methods.
    private void MovementUpdater()
    {
        if (characterVel < characterVelVector.x)
        {
            characterVelVector.x = characterVel;
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
