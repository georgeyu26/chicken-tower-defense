using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public void PlayEasyMap()
    {
        SceneManager.LoadScene("Easy");
        FindObjectOfType<GameManager>().NewGame();
        PauseMenu.paused = false;
    }
    public void PlayMedMap()
    {
        SceneManager.LoadScene("Map1");
        FindObjectOfType<GameManager>().NewGame();
    }
    public void PlayHardMap()
    {
        SceneManager.LoadScene("map2");
        FindObjectOfType<GameManager>().NewGame();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}