using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{
    private bool managementEnable;
    private bool upgradeEnable;

    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        managementEnable = false;
        upgradeEnable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown(){
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

        // Add logic for showing tower upgrades here
        managementEnable = !managementEnable;

        gameManager.towerManagementPanel.SetActive(managementEnable);
    }
}
