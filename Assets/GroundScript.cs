using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] private Material lightGround;
    [SerializeField] private Material midGround;
    [SerializeField] private Material darkGround;

    private void Start()
    {
        StartCoroutine(SetMidGround(0f));
    }

    /* IEnumerator SetLightGround(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.GetComponent<MeshRenderer>().material = lightGround;

        StartCoroutine(SetMidGround(1f));
    }*/

    IEnumerator SetMidGround(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.GetComponent<MeshRenderer>().material = midGround;

        StartCoroutine(SetDarkGround(0.78f));
    }

    IEnumerator SetDarkGround(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.GetComponent<MeshRenderer>().material = darkGround;

        StartCoroutine(SetMidGround(0.78f));
    }
}
