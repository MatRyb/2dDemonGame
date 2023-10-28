using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject colliderDaddy; // father of all colliders

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private CharacterMove characterMove;

    public GameObject spawnCollider;

    private bool colliding;

    private void Start()
    {
        CreateTrailObject();
        DropTrail();
    }

    private void CreateTrailObject()
    {
        // Create the Object and set it BEHIND the player
        GameObject obj = Instantiate(colliderDaddy, spawnCollider.transform.position, spawnCollider.transform.rotation);

        // Ensure the player object is the parent of the trail object
        obj.transform.SetParent(this.transform);

        // Ensure the tag is InActiveTrail so that it doesn't collide with the player
        obj.tag = "InActiveTrail";
    }

    private void DropTrail()
    {
        // Grab the collider object
        ColliderDaddyScript colliderObj = GetComponentInChildren<ColliderDaddyScript>();

        // Remove it from the Player parent object
        colliderObj.gameObject.transform.SetParent(null);

        // Detach code on the Collider causes delayed activation
        colliderObj.Detach();

        // Create new collider (in front of player
        CreateTrailObject();
    }

    private void OnCollisionStay(Collision collision)
    {
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!colliding)
        {
            DropTrail();
        }
    }
}
