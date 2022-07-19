
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class GameState 
{
    public int savedRound;
    public string savedDifficulty;
    public int savedHealth;
    public int savedCurrency;
    
    //List of tower data objects
    public List<TowerData> savedTowers = new List<TowerData>(); 

    public GameState (int GameRound, string Difficulty, int GameHealth, int GameCurrency, GameObject[] Towers){
        savedRound = GameRound;
        savedDifficulty = Difficulty;
        savedHealth = GameHealth;
        savedCurrency = GameCurrency;
        
        foreach (var tower in Towers)
        {
            if (tower.name == "LFP")
            {
                continue;
            }
            TowerData savedTower = new TowerData(tower);
            savedTowers.Add(savedTower);
        }
    }
}
