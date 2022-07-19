using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    private void PlayDifficulty(string difficulty)
    {
        GameSaveManager.DeleteSavedGame();
        // store difficulty somewhere
        // GameSaveManager.Difficulty = difficulty;
        //SceneManager.LoadScene(difficulty);
    }
    public void PlayEasyDifficulty() { PlayDifficulty("Easy"); }
    public void PlayMediumDifficulty() { PlayDifficulty("Medium"); }
    public void PlayHardDifficulty() { PlayDifficulty("Hard"); }
}
