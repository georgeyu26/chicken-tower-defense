using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState 
{
    public int round;
    public int health;
    public int currency; 
    public GameObject[] towers; 

    public GameState (int GameRound, int GameHealth, int GameCurrency, GameObject[] Towers){
        round = GameRound;
        health = GameHealth;
        currency = GameCurrency;
        towers = Towers;
    }
}
