using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    // WELCOME TO DEMON FM
    [SerializeField] public AudioClip[] backgroundAudioClips = null;

    private AudioSource audioSource;

    private int currentSong;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentSong = Random.Range(0,4);
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = backgroundAudioClips[currentSong];
            audioSource.Play();
            currentSong += 1;
            if(currentSong >= backgroundAudioClips.Length)
            {
                currentSong = 0;
            }
        }
    }
}
