using System.Collections;
using UnityEngine;
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

    public TowerBtn ClickedTower { get; private set; }
    private LevelManager _levelManager;

    public GameObject towerPrefab;
    public Hover hover;

    private ObjectPool Pool {get; set;}

    private int _roundNumber = 0;
    
    public TextMeshProUGUI roundText;
    public GameObject nextRoundButton;
    
    private Range _selectedTower;
    
    public GameObject TowerPreFab => towerPrefab;
    public Hover Hover => hover;

    private void Awake() {
        _roundInProgress = false;
        
        Pool = GetComponent<ObjectPool>();
        Currency = 100; // starting amount of money given to player
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
    
    public void StartRound() {
        _roundNumber++;
        roundText.text = $"Round {_roundNumber}";
        SpawnRound();
        Currency += 1000;
        _roundInProgress = true;
        nextRoundButton.SetActive(false);
    }

    private void FinishRound()
    {
        nextRoundButton.SetActive(true);
    }

    private bool AllChickensDead() => GameObject.FindGameObjectsWithTag("Chicken").Length == 0;
    

    private IEnumerator Spawn(string s)
    {
        foreach (var c in s)
            switch (c) {
                case 'a': Pool.GetObject("Chicken"); break;
                case 'b': Pool.GetObject("Cock");   break;
                default:  yield return new WaitForSeconds(c - '0'); break;
            }
    }

    private void SpawnRound()
    {
        string s = _roundNumber switch
        {
            1 => "a2a2a2a2a",
            2 => "a1a1a1a1a1a1a1a",
            3 => "b2b2b2b2b",
            4 => "b2b2b2b2b1a1a1a1a1a",
            5 => "b1b1b1b1b1b1b1b1b1b",
            6 => "aaaaaaaaaa",
            _ => ""
        };
        StartCoroutine(Spawn(s));
    }
}
