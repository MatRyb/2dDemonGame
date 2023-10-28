using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExtinguish : MonoBehaviour
{
    [SerializeField] private AudioEnviroSFX audioEnviroSFX;
    bool triggered = false;
    [SerializeField] private float time = 0.01f;
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered Fire Collider");

        if(other.gameObject.tag == "charTrig")
        {
            audioEnviroSFX.audioSource.clip = audioEnviroSFX.enviroSfx[0];
            audioEnviroSFX.audioSource.Play();
            triggered = true;
            other.GetComponent<FireExtinguish>().Extinguish(time);
            gameManager.Extinguish();
        }
    }
}
