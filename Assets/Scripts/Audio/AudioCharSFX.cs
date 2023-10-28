using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCharSFX : AudioManager
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private CharacterMove character;
    private bool characterTurning;
    private bool isAccelerated;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();
        characterTurning = false;
        

     /*   audioSource.clip = sfx[0]; // 0 -> speeding up
        audioSource.Play();
        isAccelerated = true;*/
    }

    void Update()
    {
        characterTurning = character.rotations;

        Debug.Log(isAccelerated);

        if (!audioSource.isPlaying && !isAccelerated)
        {
            Debug.Log("Trigger!!!");
            isAccelerated = true;
            audioSource.clip = sfx[0];
            audioSource.Play();
        }
        else if (!audioSource.isPlaying && isAccelerated)
        {
            if(audioSource.clip == sfx[0]) 
            {
                audioSource.clip = sfx[1];
                audioSource.loop = true;
                audioSource.Play();
            }
            //audioSource.clip = sfx[1];
            //audioSource.Play();
        }

        if (characterTurning)
        {
            isAccelerated = false;
            
        }
    }
}
