using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{
    private void PlayDifficulty(string difficulty)
    {
        GameSaveManager.DeleteSavedGame();
        GameManager.Difficulty = difficulty;
        SceneManager.LoadScene(GameManager.Map);
    }
    public void PlayEasyDifficulty() { PlayDifficulty("Easy"); }
    public void PlayMediumDifficulty() { PlayDifficulty("Medium"); }
    public void PlayHardDifficulty() { PlayDifficulty("Hard"); }
}
