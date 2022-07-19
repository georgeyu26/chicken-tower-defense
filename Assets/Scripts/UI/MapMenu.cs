using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    private void PlayMap(string map)
    {
        GameSaveManager.DeleteSavedGame();
        SceneManager.LoadScene(map);
    }
    public void PlayEasyMap() { PlayMap("Easy"); GameManager.Difficulty = 0; }
    public void PlayMedMap() { PlayMap("Medium"); GameManager.Difficulty = 1; }
    public void PlayHardMap() { PlayMap("Hard"); GameManager.Difficulty = 2; }
}