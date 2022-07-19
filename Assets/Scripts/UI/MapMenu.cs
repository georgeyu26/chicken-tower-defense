using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    private void PlayMap(string map)
    {
        GameStateManager.mapToLoad = map;
        SceneManager.LoadScene("DifficultyMenu");
    }
    public void PlayBeginnerMap() { PlayMap("Beginner"); }
    public void PlayIntermediateMap() { PlayMap("Intermediate"); }
    public void PlayAdvancedMap() { PlayMap("Advanced"); }
}