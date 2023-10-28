using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject capsule;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w"))
        {
            capsule.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown("s"))
        {
            capsule.transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown("d"))
        {
            capsule.transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown("a"))
        {
            capsule.transform.position += new Vector3(-1, 0, 0);
        }
    }
}
