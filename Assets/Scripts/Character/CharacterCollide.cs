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

    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        stateController = FindObjectOfType<StateController>();
        rb = GetComponent<Rigidbody>();
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
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Swamp)
            {
                Debug.Log("Hit a swamp!");
            }
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Farm)
            {
                Debug.Log("Hit a Farm!");
            }
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Fog)
            {
                Debug.Log("Hit some Fog!");
            }
            else if (obsScript.obstacleType == ObstacleScript.ObstacleType.Village)
            {
                Debug.Log("Hit a Village");
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

    public void OnCharDeath()
    {
        characterMove.movable = false;

        // Freezes all player movement when collission has occured.
        rb.constraints = RigidbodyConstraints.FreezeAll;

        // THIS IS WHERE THE "ON DEATH" code will go
        gameManager.HandleDeath();


        // I am become Death the Destroy of Worlds!
    }
}
