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
        if (Input.GetMouseButtonDown(0)){
            Toggle();
        }
        
    }

    public void Toggle(){
        Range range = gameObject.transform.GetChild(0).GetComponent<Range>();
        gameManager.SelectTower(range);
    }
}
