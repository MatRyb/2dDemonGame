using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class PlayOnHover : MonoBehaviour, IPointerEnterHandler
{
    public MenuMusicManager musicManager;
    public void OnPointerEnter(PointerEventData eventData)
    {
        musicManager.StartHover();
    }
}
