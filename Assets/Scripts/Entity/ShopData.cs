using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    private GameManager gameManager;

    public int cost;
    public int level = 1;
    public int upgradeCost = 100;
    public int repairCost = 100;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
}
