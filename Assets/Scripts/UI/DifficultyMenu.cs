using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    public string map;
    private void PlayDifficulty(string difficulty)
    {
        GameSaveManager.DeleteSavedGame();
        GameStateManager.difficulty = difficulty;
        SceneManager.LoadScene(GameStateManager.map);
    }
    public void PlayEasyDifficulty() { PlayDifficulty("Easy"); }
    public void PlayMediumDifficulty() { PlayDifficulty("Medium"); }
    public void PlayHardDifficulty() { PlayDifficulty("Hard"); }
}
