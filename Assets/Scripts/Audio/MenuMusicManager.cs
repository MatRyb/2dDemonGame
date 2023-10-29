using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    // Start is called before the first frame update\
    public AudioSource audioSource;
    public List<AudioClip> audioClips;


    public void StartHover()
    {
        audioSource.Stop();
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void StartPlay()
    {
        audioSource.Stop();
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}