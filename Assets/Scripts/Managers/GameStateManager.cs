using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class GameStateManager
{
    public static string mapToLoad = "Beginner";
    public static string difficulty = "Easy";

    public static int getStartingCurrency()
    {
        switch (difficulty)
        {
            case "Easy":
                return 300;
            case "Medium":
                return 200;
            case "Hard":
                return 100;
        }
        return 0;
    }

    public static int getRoundBonus(int roundNumber)
    {
        switch (difficulty)
        {
            case "Easy":
                return 15 * roundNumber + 75;
            case "Medium":
                return 10 * roundNumber + 50;
            case "Hard":
                return 5 * roundNumber + 25;
        }
        return 0;
    }
}
