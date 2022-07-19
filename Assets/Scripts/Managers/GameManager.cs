using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject towerManagementPanel;

    private int _currency;
    public TextMeshProUGUI currencyText;
    
    public int Currency
    {
        get => _currency;
        set
        {
            _currency = value;
            if (currencyText) currencyText.text = value.ToString();
        }
    }

    private int _lfpHealth;
    public TextMeshProUGUI healthText;

    public int LFPHealth
    {
        get => _lfpHealth;
        set
        {
            _lfpHealth = value;
            if (healthText) healthText.text = "<size=30> <sprite=0> </size>" + value.ToString();
        }
    }

    public GameObject LastTower { get; set; }

    public TowerBtn ClickedTower { get; private set; }
    private LevelManager _levelManager;

    public GameObject towerPrefab;
    public Hover hover;

    private ObjectPool Pool { get; set; }

    // 0 = easy, 1 = medium, 2 = hard
    private static int _difficulty = 0;
    public static int Difficulty
    {
        get => _difficulty;
        set
        {
            _difficulty = value;
        }
    }

    private static int _roundNumber;
    public static int RoundNumber
    {
        get => _roundNumber;
        set
        {
            _roundNumber = value;
        }
    }
    
    public TextMeshProUGUI roundText;
    public GameObject nextRoundButton;
    public GameObject shopButton;

    private Range _selectedTower;

    public GameObject TowerPreFab => towerPrefab;
    public Hover Hover => hover;

    private void Awake()
    {
        // General instantiation stuff
        RoundInProgress = false;
        PauseMenu.paused = false;
        Pool = GetComponent<ObjectPool>();

        // If there is a save file to load
        if (GameSaveManager.mapToLoad == SceneManager.GetActiveScene().name)
        {
            GameState data = GameSaveManager.LoadGame();

            // Fallback if there was data corruption or something
            if (data == null)
            {
                GameSaveManager.DeleteSavedGame();
                NewGame();
                return;
            }

            RoundNumber = data.savedRound;
            Currency = data.savedCurrency;
            LFPHealth = data.savedHealth;
            
            var tilescript = GameObject.Find("TileManager");
            foreach (var tower in data.savedTowers)
            {
                tilescript.GetComponent<TileScript>().LoadTower(tower);
            }
        }
        else
        {
            NewGame();
        }
        
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void NewGame()
    {
        RoundNumber = 0;
        // starting money
        switch (Difficulty)
        {
            case 0:
                Currency = 300;
                break;
            case 1:
                Currency = 200;
                break;
            case 2:
                Currency = 100;
                break;
        }
        // starting LFP health
        switch (Difficulty)
        {
            case 0:
                LFPHealth = 200;
                break;
            case 1:
                LFPHealth = 150;
                break;
            case 2:
                LFPHealth = 100;
                break;
        }
    }

    private void Update()
    {
        if (RoundInProgress && !IsCurrentlySpawning && AllChickensDead()) FinishRound();
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

    public bool RoundInProgress { get; set; }
    public bool IsCurrentlySpawning { get; set; }

    public void StartRound()
    {
        // Save before a round starts
        GameState save = new GameState(RoundNumber, LFPHealth, Currency, GameObject.FindGameObjectsWithTag("Tower"));
        GameSaveManager.SaveGame(save);

        // Augment the round number
        _roundNumber++;
        roundText.text = $"Round {_roundNumber}";
        // Update the max score
        Score.UpdateHighScore(_roundNumber);

        // Start spawning chickens
        RoundInProgress = true;
        IsCurrentlySpawning = true;
        SpawnRound();

        // Turn off UI elements that should not be accessible during a round
        nextRoundButton.SetActive(false);
        shopButton.GetComponent<ShopManager>().DeactivateShop();
        shopButton.SetActive(false);
    }

    private void FinishRound()
    {
        // Reward the player for finishing the round
        switch (Difficulty)
        {
            case 0:
                Currency += 2 * RoundNumber + 150;
                break;
            case 1:
                Currency += RoundNumber + 100;
                break;
            case 2:
                Currency += RoundNumber / 2 + 50;
                break;
        }

        // Turn off round-in-progress indicators
        RoundInProgress = false;
        IsCurrentlySpawning = false;

        // Reactivate UI elements
        nextRoundButton.SetActive(true);
        shopButton.SetActive(true);

        // Save after a round is over
        GameState save = new GameState(RoundNumber, LFPHealth, Currency, GameObject.FindGameObjectsWithTag("Tower"));
        GameSaveManager.SaveGame(save);
    }   

    private bool AllChickensDead() => GameObject.FindGameObjectsWithTag("Chicken").Length == 0;

    private IEnumerator Spawn(string s)
    {
        foreach (var c in s)
        {
            switch (c)
            {
                case 'a':
                    Pool.GetObject("Chick");
                    break;
                case 'b':
                    Pool.GetObject("Chicken");
                    break;
                case 'c':
                    Pool.GetObject("Cock");
                    break;
                case 'd':
                    Pool.GetObject("Undead");
                    break;
                case 'e':
                    Pool.GetObject("RegimeCockman");
                    break;
                default:
                    yield return new WaitForSeconds(c - '0');
                    break;
            }
        }

        FindObjectOfType<GameManager>().IsCurrentlySpawning = false;
    }

    private void SpawnRound()
    {
        var s = _roundNumber switch
        {
            1 => "a",
            2 => "a8a8a",
            3 => "a7a7a7a",
            4 => "a6a6a6a6a",
            5 => "a5a5a5a5a5a",
            6 => "a4a4a4a4a4a4a",
            7 => "a3a3a3a3a3a3a3a",
            8 => "a2a2a2a2a2a2a2a2a",
            9 => "a1a1a1a1a1a1a1a1a1a",
            10 => "b",
            11 => "a9a9b",
            12 => "a8a8b8b",
            13 => "a7a7a7b7b7b",
            14 => "a6b6a6b6a6b6a6b",
            15 => "a5a5a5b5b5b",
            16 => "a4b4a4b4b4b4b",
            17 => "a3a3b3b3a3a3a3b3b3b",
            18 => "a2a2a2a2a2b2b2b2b2b",
            19 => "b1b1b1b1b1b1b1b1b1b",
            20 => "c",
            21 => "a9b9c",
            22 => "a8a8b8b8c",
            23 => "a7a7a7b7b7b7c7c",
            24 => "a6a6b6b6a6a6c6c",
            25 => "a5c5b5c5a5c5c5c",
            26 => "c4c4a4b4a4b4c4c",
            27 => "a3a3b3c3b3c3c3c3c",
            28 => "c2c2c2c2b2b2b2c2c2c",
            29 => "c1c1c1c1c1c1c1c1c1c",
            30 => "d",
            31 => "d9a9b9c9a9d",
            32 => "a8b8d8c8c8d8b8a",
            33 => "a7b7c7c7b7d7a7d7d",
            34 => "d6d6d6b6b6a6c6a6d",
            35 => "d5d5b5b5c5c5c5d5d",
            36 => "d4c4d4c4d4d",
            37 => "d3a3b3b3c3a3d",
            38 => "d2a2b2c2d2a2b2d2d2d",
            39 => "d1d1d1d1d1d1d1d1d1d",
            40 => "e",
            41 => "a9b9c9d9e",
            42 => "a8a8b8b8c8d8e",
            43 => "e7b7d7c7d7d7e7e",
            44 => "e6b6c6e6b6a6e6c6d6e",
            45 => "e5e5e5e5e",
            46 => "e4b4a4c4e4a4b4e4e4e",
            47 => "a3b3a3e3e3e3c3a3e3e",
            48 => "e2a2b2e2c2d2e2b2e2e",
            49 => "e1e1e1e1e1e1e1e1e1e",
            50 => "e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e1e",
            _ => "a1b1c1d1e"
        };
        StartCoroutine(Spawn(s));
    }

    public float CalculateDamageModifier(ObjectType attack, ObjectType victim)
    {
        // Row corresponds to type of attack, column corresponds to type of victim
        float[,] multiplierSheet =
        {
            //               Nat   Med   Kit   Mil   Fut
            /* Nature   */ { 1.0f, 1.0f, 0.5f, 0.0f, 0.0f },
            /* Medieval */ { 2.0f, 0.0f, 1.0f, 1.5f, 1.0f },
            /* Kitchen  */ { 0.5f, 1.5f, 1.0f, 1.0f, 0.0f },
            /* Military */ { 1.0f, 0.5f, 1.5f, 1.0f, 1.0f },
            /* Future   */ { 1.5f, 0.5f, 1.5f, 0.5f, 1.5f },
        };

        return multiplierSheet[(int)attack, (int)victim];
    }

    public void GameOver()
    {
        GameSaveManager.DeleteSavedGame();
        SceneManager.LoadScene("GameOver");
    }
}