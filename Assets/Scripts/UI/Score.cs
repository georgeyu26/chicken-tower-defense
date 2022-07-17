using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    public void Update()
    {
        scoreText.text = "HIGHSCORE : " + GetHighScore();
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
    }

    /// <summary>
    ///   <para>UpdateHighScore writes updates the Highest Recorded Round and writes that to disk.</para>
    /// </summary>
    public static void UpdateHighScore(int curScore)
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int prevHighScore = PlayerPrefs.GetInt("HighScore");
            if (prevHighScore < curScore)
            {
                PlayerPrefs.SetInt("HighScore", curScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", curScore);
        }

        PlayerPrefs.Save();
    }
}