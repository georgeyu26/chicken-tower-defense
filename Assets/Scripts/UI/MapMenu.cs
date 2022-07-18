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
    public void PlayEasyMap() { PlayMap("Easy"); }
    public void PlayMedMap() { PlayMap("Medium"); }
    public void PlayHardMap() { PlayMap("Hard"); }
}