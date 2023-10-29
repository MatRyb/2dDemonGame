using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteContoller : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume m_Volume;
    [SerializeField]
    private Vignette m_Vignette;
    [SerializeField]
    private float promptTime;
    [SerializeField]
    private float animationDuration;
    float currentTime = 0f;

    private void Awake()
    {
        
        //FloatParameter opacity = new FloatParameter();
        //opacity.value = 0.5f;
        //m_Vignette.opacity = opacity;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > promptTime && currentTime < promptTime + animationDuration)
        {
            m_Volume.weight = Mathf.Lerp(1.0f,0.0f,(currentTime-promptTime)/animationDuration);
        }
    }






}
