using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
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

    private Transform childAxis;

    bool rotations;

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
        characterVelVector.y = characterVel;
        pivot = GetComponent<Transform>();
        childAxis = GetComponentInChildren<Transform>();
        rotations = true;
    }

    private void FixedUpdate()
    {
        if(rotations)
        {
            if(characterVelVector.y > characterVel * characterSlowDown)
            {
                characterVelVector.y = characterVelVector.y * 0.90f;
            }
            pivot.transform.Translate(characterVelVector);
        }
        else
        {
            if(characterVelVector.y < characterVel) 
            {
                characterVelVector.y += characterVelSpeedUpAfterTurningMovement;
                pivot.transform.Translate(characterVelVector);
            }
            else
            {
                pivot.transform.Translate(characterVelVector * 1.0f);
            }

        }


        pivot.transform.Rotate(characterRotationVector);
        if (characterRotationVector.z != 0 && !rotations)
        {
            characterRotationVector.z *= smooth;
        }
    }

    private void Update()
    {
        if (characterVel < characterVelVector.y)
        { 
            characterVelVector.y = characterVel;
        }

        rotations = false;
        if (Input.GetKey(KeyCode.A))
        {
            characterRotationVector.z = characterRotation;
            rotations = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterRotationVector.z = -characterRotation;
            rotations = true;
        }
    }
}
