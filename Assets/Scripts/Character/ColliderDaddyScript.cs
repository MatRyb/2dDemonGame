using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDaddyScript : MonoBehaviour
{
    private Vector3 randLoc;
    private Vector3 curLoc;

    private float t = 0f;
    

    public void Detach()
    {
        curLoc = transform.position;

        float randomizer = Random.Range(0.2f,0.5f);

        randLoc = new Vector3(curLoc.x - randomizer, curLoc.y, curLoc.z - randomizer);

        StartCoroutine(LerpFunction());

        StartCoroutine(DelayToActivate(1f));
    }

    IEnumerator DelayToActivate(float delay)
    {
        // wait for 1 sec
        yield return new WaitForSeconds(delay);

        // set trail to active
        this.tag = "ActiveTrail";
        this.GetComponent<SphereCollider>().isTrigger = false;
    }

    IEnumerator LerpFunction()
    {
        while (t < 1)
        {
            t += Time.deltaTime;

            if (t > 1) t = 1;

            transform.position = Vector3.Lerp(curLoc, randLoc, t);

            yield return null;
        }
    }
}
