using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject deathMenu;
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ReturnToMenu()
    {
        deathMenu.SetActive(false);
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(1);
    }
}
