using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollide : MonoBehaviour
{
    CharacterMove characterMove;
    Rigidbody rb;
    [SerializeField]
    GameManager gameManager;

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "charColl") 
        {
            OnCharDeath();
        }
    }

    public void OnCharDeath()
    {
        characterMove.movable = false;

        // Freezes all player movement when collission has occured.
        rb.constraints = RigidbodyConstraints.FreezeAll;

        // THIS IS WHERE THE "ON DEATH" code will go
        gameManager.HandleDeath();
    }
}
