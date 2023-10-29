using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScreen : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] clips;

    private int counter = 0;

    [SerializeField] GameObject[] screens;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            if(counter == 3)
            {
                SceneManager.LoadScene(0);
            }

            if(counter == 0)
            {
                audio.clip = clips[counter];
                audio.Play();
                screens[counter].SetActive(true);
            }
            else
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                }

                audio.clip = clips[counter];
                audio.Play();

                screens[counter].SetActive(true);
                screens[counter-1].SetActive(false);
            }

            counter++;  
        }
    }
}
