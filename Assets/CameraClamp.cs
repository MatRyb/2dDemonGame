using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField] private Transform targetToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -30.5f, 30.5f),
            transform.position.y,
            Mathf.Clamp(targetToFollow.position.z, -30f, 30f)
            );
    }
}
