using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerMenu : MonoBehaviour
{
    private bool managementEnable;

    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        managementEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.LastTower == null || gameManager.RoundInProgress){
            managementEnable = false;
            gameManager.towerManagementPanel.SetActive(managementEnable);
        }
    }

    void OnMouseDown(){
        Debug.Log(gameManager.LastTower);
        if(gameManager.LastTower != null){
            TowerMenu last = (TowerMenu) gameManager.LastTower.GetComponent(typeof(TowerMenu));
            last.Toggle();
        }
        
        gameManager.LastTower = gameObject;
        Toggle();
    }
    /* Towers to add

    Basic
    - Squirrel
    - Goose

    Medieval
    - Watermelon launcher
    - Knight

    Modern Kitchen
    - Oven
    - Fryer

    Military
    - Turret
    - Rocket launcher

    Futuristic
    - Laser turret
    - The Colonel

    */
    

    public void Toggle(){
        Range range = gameObject.transform.GetChild(0).GetComponent<Range>();
        gameManager.SelectTower(range);

        managementEnable = !managementEnable;
        gameManager.towerManagementPanel.SetActive(managementEnable);

        if(managementEnable){
            TextMeshProUGUI sellValue = GameObject.Find("SellValue").GetComponent<TextMeshProUGUI>();
            sellValue.text = "+" + (gameManager.LastTower.GetComponent<ShopData>().cost/2).ToString();  

            TextMeshProUGUI repairCost = GameObject.Find("RepairCost").GetComponent<TextMeshProUGUI>();
            repairCost.text = "-" + gameManager.LastTower.GetComponent<ShopData>().repairCost.ToString();

            TextMeshProUGUI upgradeCost = GameObject.Find("UpgradeCost").GetComponent<TextMeshProUGUI>();
            upgradeCost.text = "-" + gameManager.LastTower.GetComponent<ShopData>().upgradeCost.ToString();

            Button repairBtn = GameObject.Find("Repair").GetComponent<Button>();
            repairBtn.interactable = gameManager.Currency > gameManager.LastTower.GetComponent<ShopData>().repairCost;

            Button upgradeBtn = GameObject.Find("Upgrade").GetComponent<Button>();
            upgradeBtn.interactable = gameManager.Currency > gameManager.LastTower.GetComponent<ShopData>().upgradeCost;
        }
    }
}
