using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public bool showShop;

    private GameManager gameManager;

    [SerializeField]
    private GameObject shopPanel;

    private Tilemap _map;

    [SerializeField] 
    public Tile goodTile;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        showShop = false;
        shopPanel.SetActive(false);
        _map = GameObject.Find("Ground").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle(){
        if (PauseMenu.paused){
            return;
        }
        showShop = !showShop;
        shopPanel.SetActive(showShop);
    }

    public void DeactivateShop(){
        showShop = false;
        shopPanel.SetActive(false);
    }

    public void Sell()
    {
        int value = gameManager.LastTower.GetComponent<ShopData>().cost/2;
        gameManager.Currency += value;
        Vector3Int tilePos = Vector3Int.FloorToInt(gameManager.LastTower.transform.position);
        _map.SetTile(tilePos, goodTile);
        Destroy(gameManager.LastTower);
    }

    public void Upgrade()
    {
        gameManager.LastTower.GetComponent<ShopData>().level += 1;
        gameManager.LastTower.GetComponent<TowerHealth>().maxHealth = (int)(1.4*gameManager.LastTower.GetComponent<TowerHealth>().maxHealth);
        gameManager.LastTower.GetComponent<AimAndShoot>().sleepTime =  (int)(1.4*gameManager.LastTower.GetComponent<AimAndShoot>().sleepTime);

        gameManager.Currency -= gameManager.LastTower.GetComponent<ShopData>().upgradeCost;

        gameManager.LastTower.GetComponent<ShopData>().upgradeCost = (int)(100 * Mathf.Pow(2,gameManager.LastTower.GetComponent<ShopData>().level));
    }

    public void Repair()
    {
        gameManager.LastTower.GetComponent<TowerHealth>().currentHealth = gameManager.LastTower.GetComponent<TowerHealth>().maxHealth;
        int repairCost = gameManager.LastTower.GetComponent<ShopData>().repairCost;
        gameManager.Currency -= repairCost;
        gameManager.LastTower.GetComponent<ShopData>().repairCost = (int) (gameManager.LastTower.GetComponent<ShopData>().repairCost*1.5);
    }
}
