using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollide : MonoBehaviour
{
    CharacterMove characterMove;
    Rigidbody rb;
    [SerializeField]
    GameManager gameManager;
    StateController stateController;

    [SerializeField] private float timeToDeath = 0.5f;
    [SerializeField] private float timer;

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        stateController = FindObjectOfType<StateController>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(characterMove.slowed == true)
        {
            timer = timer + Time.deltaTime;

            if (timer > timeToDeath)
            {
                OnCharDeath();
                characterMove.slowed = false; // to prevent constant calling
            }
        }
        else if (characterMove.slowed == false && timer != 0)
        {
            timer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "charColl") 
        {
            ObstacleScript obsScript = collision.gameObject.GetComponent<ObstacleScript>();

            if (obsScript.obstacleType == ObstacleScript.ObstacleType.Block)
            {
                OnCharDeath();
            }
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Farm)
            {
                Debug.Log("Hit a Farm!");
            }
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Village)
            {
                OnCharDeath();
            }
            else
            {
                Debug.Log("Hit an Obstacle with no valid Enum, " +
                    "or enum is not included in Collission Script.");
            }
        }
        else if (collision.gameObject.tag == "ActiveTrail")
        {
            // This is logic when hitting the smoke
            OnCharDeath();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "charColl")
        {
            ObstacleScript obsScript = collision.gameObject.GetComponent<ObstacleScript>();

            if (obsScript.obstacleType == ObstacleScript.ObstacleType.Swamp)
            {
                characterMove.slowed = true;
            }
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Fog)
            {
                characterMove.boosted = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "charColl")
        {
            ObstacleScript obsScript = collision.gameObject.GetComponent<ObstacleScript>();

            characterMove.slowed = false;
            
            characterMove.boosted = false;
        }
    }

    public void OnCharDeath()
    {
        characterMove.movable = false;

        // THIS IS WHERE THE "ON DEATH" code will go
        gameManager.HandleDeath();

        // Freezes all player movement when collission has occured.
        rb.constraints = RigidbodyConstraints.FreezeAll;

        // I am become Death the Destroy of Worlds!
    }
}
