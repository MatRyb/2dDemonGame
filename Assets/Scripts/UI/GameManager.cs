using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject deathMenu;
    //[SerializeField]
    //private GameObject winMenu;
    [SerializeField]
    private Timer timer;
    public void HandleDeath()
    {
        deathMenu.SetActive(true);
    }      
}
