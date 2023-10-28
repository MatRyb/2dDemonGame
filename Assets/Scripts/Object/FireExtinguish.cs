using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguish : MonoBehaviour
{
    public void Extinguish(float time)
    {
        Destroy(gameObject, time);
    }


}
