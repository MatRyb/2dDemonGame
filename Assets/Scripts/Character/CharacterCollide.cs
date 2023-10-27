using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollide : MonoBehaviour
{
    CharacterMove characterMove;
    void Start()
    {
        characterMove = GetComponent<CharacterMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "charColl") 
        {
            characterMove.SetRot(0f);
            characterMove.SetVel(0f);
        }
    }
}
