using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameSaveManager
{
    public static void SaveGame(int GameRound, int GameHealth, int GameCurrency, GameObject[] Towers){
        BinaryFormatter formatter = new BinaryFormatter();
        string saveFilePath = Application.persistentDataPath + "/gameData";
        FileStream stream = new FileStream(saveFilePath, FileMode.Create);

        GameState data = new GameState(GameRound, GameHealth, GameCurrency, Towers);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static GameState LoadGame(){
        string saveFilePath = Application.persistentDataPath + "/gameData";
        if (File.Exists(saveFilePath)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveFilePath, FileMode.Open);
            
            GameState data = formatter.Deserialize(stream) as GameState;
            stream.Close();
            return data;
        }
        else{
            Debug.LogError("Save file not found in " + saveFilePath);
            return null;
        }
    }
}
