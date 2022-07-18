using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Easy");
        FindObjectOfType<GameManager>().NewGame();
    }

    public void QuitGame()
    {
        Debug.Log("GAME IS QUITTING");
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Easy");
        FindObjectOfType<GameManager>().LoadGame();
    }
}