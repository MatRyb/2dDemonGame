using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject colliderDaddy; // father of all colliders

    List<GameObject> colliders;
    List<GameObject> collidersQueue;
    GameObject newCollider;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private CharacterMove characterMove;
    

    int i = 0;


    private void Start()
    {
        colliders = new List<GameObject>();
        collidersQueue   = new List<GameObject>();
        //collidersQueue.Add(colliderDaddy);    // i can't add this line beacuse it fucks everything up
                                                // i have truly no idea wtf is going on
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        newCollider = Instantiate(colliderDaddy);
        newCollider.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        newCollider.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
        newCollider.SetActive(true);

        /*
        i++;
        
        if (characterMove.GetVel() != 0)
        {
            if(characterMove.GetVel()*i >= 0.5) // 7.0 jest spoko ale nie pamietam dlaczego :))
            {
                newCollider = Instantiate(colliderDaddy);
                newCollider.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                newCollider.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
                collidersQueue.Add(newCollider);
                i = 0;
            }
        }
        if(collidersQueue.Count > 6) //number of colliders that will be inactive at the time
        {
            collidersQueue[0].SetActive(true);
            colliders.Add(collidersQueue[0]);
            collidersQueue.RemoveAt(0);
        }
        */
    }
}
