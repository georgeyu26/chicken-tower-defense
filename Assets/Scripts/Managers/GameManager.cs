using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject towerManagementPanel;

    private int _currency;
    public TextMeshProUGUI currencyText;

    public int Currency {
        get => _currency;
        set {
            _currency = value;
            currencyText.text = value.ToString();
        }
    }

    private int _lfpHealth;
    public TextMeshProUGUI healthText;

    public int LFPHealth {
        get => _lfpHealth;
        set {
            _lfpHealth = value;
            healthText.text = "<size=30> <sprite=0> </size>" + value.ToString();
        }
    }

    private GameObject _lastTower;
    public GameObject LastTower {
        get => _lastTower;
        set {
            _lastTower = value;
        }
    }

    public TowerBtn ClickedTower { get; private set; }
    private LevelManager _levelManager;

    public GameObject towerPrefab;
    public Hover hover;

    private ObjectPool Pool {get; set;}

    private int _roundNumber = 0;
    
    public TextMeshProUGUI roundText;
    public GameObject nextRoundButton;
    public GameObject shopButton;
    
    private Range _selectedTower;
    
    public GameObject TowerPreFab => towerPrefab;
    public Hover Hover => hover;

    private void Awake() {
        _roundInProgress = false;
        
        Pool = GetComponent<ObjectPool>();
        Currency = 1000; // starting amount of money given to player
        LFPHealth = 100;
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (_roundInProgress && AllChickensDead())
        {
            FinishRound();
        }
    }

    public void SelectTower(Range tower)
    {
        _selectedTower = tower;
        _selectedTower.Select();
    }

    public void DisableTower(Range tower)
    {
        _selectedTower = tower;
        _selectedTower.Disable();
    }

    public void PickTower(TowerBtn tower)
    {
        if (PauseMenu.paused) return;
        if (Currency < tower.Cost) return;
        ClickedTower = tower;
        _levelManager.Placing = true;
        hover.Activate(tower.Sprite);
    }

    private bool _roundInProgress;
    public bool RoundInProgress {
        get => _roundInProgress;
    }
    
    public void StartRound() {
        _roundNumber++;
        roundText.text = $"Round {_roundNumber}";
        SpawnRound();
        Currency += 1000;
        _roundInProgress = true;
        nextRoundButton.SetActive(false);


        ShopManager shop = (ShopManager) shopButton.GetComponent(typeof(ShopManager));
        shop.DeactivateShop();
        shopButton.SetActive(false);
    }

    private void FinishRound()
    {
        nextRoundButton.SetActive(true);
        shopButton.SetActive(true);
    }

    private bool AllChickensDead() => GameObject.FindGameObjectsWithTag("Chicken").Length == 0;
    

    private IEnumerator Spawn(string s)
    {
        foreach (var c in s)
            switch (c) {
                case 'a': Pool.GetObject("Chick"); break;
                case 'b': Pool.GetObject("Chicken"); break;
                case 'c': Pool.GetObject("Cock"); break;
                case 'd': Pool.GetObject("Undead"); break;
                case 'e': Pool.GetObject("RegimeCockman"); break;
                default: yield return new WaitForSeconds(c - '0'); break;
            }
    }

    private void SpawnRound()
    {
        string s = _roundNumber switch
        {
            1 => "a2b2c2d2e",
            2 => "b2b2b2b2b",
            3 => "c2c2c2c2c",
            4 => "d2d2d2d2d",
            5 => "e2e2e2e2e",
            _ => ""
        };
        StartCoroutine(Spawn(s));
    }
}
