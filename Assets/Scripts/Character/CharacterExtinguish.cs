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
        if (other.gameObject.tag == "charTrig")
        {
            audioEnviroSFX.audioSource.clip = audioEnviroSFX.enviroSfx[0];
            audioEnviroSFX.audioSource.Play();
            triggered = true;
            other.GetComponent<FireExtinguish>().Extinguish(time);
            gameManager.Extinguish();
        }

        if (other.gameObject.tag == "charColl")
        {
            ObstacleScript obsScript = other.gameObject.GetComponent<ObstacleScript>();

            if (obsScript.obstacleType == ObstacleScript.ObstacleType.Fog)
            {
                audioEnviroSFX.audioSource.clip = audioEnviroSFX.enviroSfx[1];
                audioEnviroSFX.audioSource.Play();
                // fooo!
            }
        }
    }
}
