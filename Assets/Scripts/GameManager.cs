using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TowerBtn ClickedTower { get; private set; }
    private LevelManager levelManager;

    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private Hover hover;

    public GameObject TowerPreFab{
        get {
            return towerPrefab;
        }
    }

    public Hover Hover {
        get {
            return hover;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickTower(TowerBtn tower){
        this.ClickedTower = tower;
        levelManager.Placing = true;
        hover.Activate(tower.Sprite);
    }
}
