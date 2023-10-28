using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalTimeDisplay;
    [SerializeField]
    private GameObject deathMenu;
    [SerializeField]
    private GameObject winMenu;
    //[SerializeField]
    //private GameObject winMenu;
    [SerializeField]
    private Timer timer;
    public int numberOfFires = 7;
    private int points = 0;
    public void HandleDeath()
    {
        deathMenu.SetActive(true);
    }      
    public void Extinguish()
    {
        points++;
        if(points >= numberOfFires)
        {
            winMenu.SetActive(true);
            float gameTime = timer.getWinTime();
            int minutes = (int)gameTime / 60;
            int seconds = (int)gameTime % 60;
            if (minutes < 10)
            {
                finalTimeDisplay.text = "0";
            }
            finalTimeDisplay.text += minutes + ":";
            if (seconds % 60 < 10)
            {
                finalTimeDisplay.text += "0";
            }
            finalTimeDisplay.text += seconds;
            Time.timeScale = 0;
        }
    }
}
