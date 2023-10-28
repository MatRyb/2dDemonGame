using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExtinguish : MonoBehaviour
{
    bool triggered = false;
    [SerializeField] private float time = 0.01f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "charTrig")
        {
            triggered = true;
            other.GetComponent<FireExtinguish>().Extinguish(time);
        }
    }
}
