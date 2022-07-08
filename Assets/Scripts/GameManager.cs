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

    private Range selectedTower;
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

    public void SelectTower(Range tower){
        selectedTower = tower;
        selectedTower.Select();
    }

    public void DisableTower(Range tower){
        selectedTower = tower;
        selectedTower.Disable();
    }

    public void PickTower(TowerBtn tower){
        this.ClickedTower = tower;
        levelManager.Placing = true;
        hover.Activate(tower.Sprite);
    }
}
