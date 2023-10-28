using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollide : MonoBehaviour
{
    CharacterMove characterMove;
    Rigidbody rb;

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "charColl") 
        {
            characterMove.movable = false;

            // Freezes all player movement when collission has occured.
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
