using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnviroSFX : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip[] enviroSfx = null;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
