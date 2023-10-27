using System.Collections;
using System.Collections.Generic;
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



    public void SwitchToLevelMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void SwitchToMainMenu()
    {
        levelMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void SwitchToSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu?.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
