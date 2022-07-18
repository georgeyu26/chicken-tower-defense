using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        GameSaveManager.FindSavedGame();
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("MapMenu");
    }

    public void QuitGame()
    {
        Debug.Log("GAME IS QUITTING");
        Application.Quit();
    }

    public void LoadGame()
    {
        if (GameSaveManager.mapToLoad == "") { return; } // no save to load, button does nothing
        SceneManager.LoadScene(GameSaveManager.mapToLoad);
    }
}