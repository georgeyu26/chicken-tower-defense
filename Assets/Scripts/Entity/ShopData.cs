using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int cost;

    private GameManager gameManager;

    public int level;

    public int upgradeCost;
    public int repairCost;
    void Awake()
    {
        level = 1;
        upgradeCost = 100;
        repairCost = 100;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
