using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // the menus are empty gameobjects that have children
    // we disable/enable them to change menus
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject levelMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject scoresMenu;
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;



    public void SwitchToLevelMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void SwitchToMainMenu()
    {
        levelMenu.SetActive(false);
        settingsMenu.SetActive(false);
        scoresMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void SwitchToSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu?.SetActive(true);
    }
    public void SwitchToScoresMenu()
    {
        mainMenu.SetActive(false);
        scoresMenu.SetActive(true);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayLevel5()
    {
        SceneManager.LoadScene(5);
    }

    public void DisplayTopScores()
    {
        scoreDisplay.text = "";
        LeaderBoard ld = (LeaderBoard)FindObjectsOfType(typeof(LeaderBoard))[0];
        ld.SortScores();
        for(int i = 0; i < 3; i++)
        {
            if (i < ld.scores.Count)
            {
                scoreDisplay.text += (i+1) + " " + ld.scores[i].name + " " + ld.scores[i].score + "\n";
            }
        }
    }



    public void QuitGame()
    {
        Application.Quit();
    }


}
