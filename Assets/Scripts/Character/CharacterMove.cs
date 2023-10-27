using System.Collections;
using System.Collections.Generic;
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

    bool rotations;

    public void SetVel(float value) 
    { 
        characterVel = value; 
    }

    public void SetRot(float value)
    {
        characterRotation = value;
    }

    void Start()
    {
        character = GetComponent<Transform>();
        rotations = true;
    }

    private void FixedUpdate()
    {
        character.transform.Translate(characterVelVector);

        character.transform.Rotate(characterRotationVector);
        if (characterRotationVector.z != 0 && !rotations)
        {
            characterRotationVector.z *= smooth;
        }
    }

    private void Update()
    {
        characterVelVector.y = characterVel;

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
