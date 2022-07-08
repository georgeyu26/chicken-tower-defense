using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
    - Monkey
    - Fry Cook

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
    }
}
