using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollider : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private GameObject colliderDaddy; // father of all colliders
    List<GameObject> colliders;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private CharacterMove characterMove;
    GameObject newCollider;


    int i = 0;
    bool isWaitingToBePlaced = false;
    private void Start()
    {
        colliders = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        i++;
        
        if (characterMove.GetVel() != 0)
        {
            if(characterMove.GetVel()*i >= 7.0)
            {
                if (newCollider != null)
                {
                    newCollider.SetActive(true);
                    colliders.Add(newCollider);
                    isWaitingToBePlaced = false;
                }
                newCollider = Instantiate(colliderDaddy);
                newCollider.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                newCollider.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
                i = 0;
                isWaitingToBePlaced = true;

            }
        }
    }
}
