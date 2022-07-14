using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    }

    void OnMouseDown(){
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
    }
}
