using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDaddyScript : MonoBehaviour
{
    //public bool active;

    public void Detach()
    {
        StartCoroutine(DelayToActivate(1f));
    }

    IEnumerator DelayToActivate(float delay)
    {
        // wait for 1 sec
        yield return new WaitForSeconds(delay);

        // set trail to active
        this.tag = "charColl";
        this.GetComponent<SphereCollider>().isTrigger = false;
    }
}
