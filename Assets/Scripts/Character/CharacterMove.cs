using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] Transform character;

    Vector3 characterVelVector = Vector3.zero;
    Vector3 characterRotationVector = Vector3.zero;

    [SerializeField]
    [Range(0, 5)]
    private float characterVel;

    [SerializeField]
    [Range(0, 5)]
    private float characterRotation = 0;

    private float smooth = 0.01f;

    bool rotations;

    void Start()
    {
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
