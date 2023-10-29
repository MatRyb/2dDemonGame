using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalTimeDisplay;
    [SerializeField] AudioEnviroSFX audio;
    [SerializeField] private GameObject deathMenu;
    [SerializeField]
    private GameObject winMenu;
    [SerializeField]
    private GameObject scoresMenu;
    //[SerializeField]
    //private GameObject winMenu;
    [SerializeField]
    private TMP_InputField playerName;
    [SerializeField]
    private Timer timer;
    public int numberOfFires = 7;
    private int points = 0;
    public void HandleDeath()
    {
        audio.audioSource.Stop();
        audio.audioSource.clip = audio.enviroSfx[2];
        audio.audioSource.Play();
        deathMenu.SetActive(true);
    }      
    public void Extinguish()
    {
        points++;
        if(points >= numberOfFires)
        {
            audio.audioSource.Stop();
            audio.audioSource.clip = audio.enviroSfx[3];
            audio.audioSource.Play();
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
    public void SaveScore()
    {
        LeaderBoard ld = (LeaderBoard)FindObjectsOfType(typeof(LeaderBoard))[0];
        ld.AddRecord(playerName.text, timer.getWinTime(), SceneManager.GetActiveScene().buildIndex);
        playerName.text = "";
        winMenu.SetActive(true);
        scoresMenu.SetActive(false);
    }
    public void OpenScoreSavingMenu()
    {
        winMenu.SetActive(false);
        scoresMenu.SetActive(true);
    }

}
