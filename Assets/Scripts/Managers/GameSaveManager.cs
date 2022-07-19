using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class GameSaveManager
{
    public static string mapToLoad = "";
    public static string difficulty = "";
    
    public static void SaveGame(GameState data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        mapToLoad = SceneManager.GetActiveScene().name;
        string saveFilePath = Application.persistentDataPath + "/" + mapToLoad + ".save";

        FileStream stream = new FileStream(saveFilePath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
        
        mapToLoad = SceneManager.GetActiveScene().name;
    }

    public static GameState LoadGame()
    {
        var saveFilePath = Application.persistentDataPath + "/" + mapToLoad + ".save";
        if (mapToLoad != "" && File.Exists(saveFilePath)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveFilePath, FileMode.Open);
            
            GameState data = formatter.Deserialize(stream) as GameState;
            stream.Close();
            return data;
        }
        
        // No save file found: should never get here
        return null;
    }

    public static void DeleteSavedGame()
    {
        var filePath = Application.persistentDataPath + "/" + mapToLoad + ".save";
        if (File.Exists(filePath)) { File.Delete(filePath); }
        mapToLoad = "";
        difficulty = "";
    }

    public static void FindSavedGame()
    {
        foreach (var map in new[] { "Beginner", "Intermediate", "Advanced" })
        {
            var filePath = Application.persistentDataPath + "/" + map + ".save";
            if (File.Exists(filePath)) { mapToLoad = map; }
        }
    }
}
