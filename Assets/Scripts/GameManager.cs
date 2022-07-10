using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    private int currency;
    [SerializeField]
    private TextMeshProUGUI currencyTxt;

    public int Currency{
        get{
            return currency;
        }
        set{
            this.currency = value;
            this.currencyTxt.text = value.ToString() + " $";
        }
    }

    public TowerBtn ClickedTower { get; private set; }
    private LevelManager levelManager;

    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private Hover hover;

    public ObjectPool Pool {get; set;}

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

    private void Awake() {
        Pool = GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Currency = 100; // starting amount of money given to player
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

    public void StartRound() {
        StartCoroutine(SpawnRound());
    }

    private IEnumerator SpawnRound() {
        int monsterIndex = Random.Range(0, 2);

        string type = string.Empty;

        switch (monsterIndex) {
            case 0:
                type = "Chicken";
                break;
            case 1:
                type = "Cock";
                break;
        }

        Pool.GetObject(type);

        yield return new WaitForSeconds(2.5f);
    }
}
