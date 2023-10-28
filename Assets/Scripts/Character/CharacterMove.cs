using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] Transform character;

    private Vector3 characterVelVector = Vector3.zero;
    private Vector3 characterRotationVector = Vector3.zero;

    [SerializeField]
    [Range(0, 5)]
    private float characterVel = 0.1f;

    [SerializeField]
    [Range(0, 5)]
    private float characterRotation = 1.0f;

    private float smooth = 0.01f;
    private float characterVelSpeedUpAfterTurningMovement = 0.003f;

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
        character = GetComponent<Transform>();
        rotations = true;
    }

    private void FixedUpdate()
    {
        if(rotations)
        {
            if(characterVelVector.y > characterVel * 0.5f)
            {
                characterVelVector.y = characterVelVector.y * 0.90f;
            }
            character.transform.Translate(characterVelVector);
        }
        else
        {
            if(characterVelVector.y < characterVel) 
            {
                characterVelVector.y += characterVelSpeedUpAfterTurningMovement;
                character.transform.Translate(characterVelVector);
            }
            else
            {
                character.transform.Translate(characterVelVector * 1.0f);
            }

        }


        character.transform.Rotate(characterRotationVector);
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
