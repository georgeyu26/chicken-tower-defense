using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBtn : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private Button towerBtn;

    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int cost;

    public int Cost{
        get{
            return cost;
        }
    }

    private void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update(){
        if(gameManager.Currency < this.cost){
            towerBtn.interactable = false;
        }
        else{
            towerBtn.interactable = true;
        }
    }
    
    public GameObject TowerPrefab{
        get{
            return towerPrefab;
        }
    }

    public Sprite Sprite {
        get {
            return sprite;
        }
    }
}
