using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollide : MonoBehaviour
{
    CharacterMove characterMove;
    void Start()
    {
        characterMove = GetComponentInParent<CharacterMove>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "charColl" || collision.gameObject.tag == "ActiveTrail")  // activeTrail and charcoll are practically the same
        {                                                                                        // they are both there not to fuck up older code ;)
            characterMove.SetRot(0f);
            characterMove.SetVel(0f);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "DormantTrail")
        {
            collision.gameObject.tag = "ActiveTrail";
        }
    }
}
