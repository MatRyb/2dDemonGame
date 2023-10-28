using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnviroSFX : AudioManager
{
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
