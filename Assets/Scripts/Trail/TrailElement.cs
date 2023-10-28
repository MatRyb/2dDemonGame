using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailElement : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.tag == "DormantTrail")
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.tag = "DormantTrail";
        }

    }
}
