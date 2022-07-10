using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TowerBtn ClickedTower { get; private set; }
    private LevelManager levelManager;

    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private Hover hover;

    public ObjectPool Pool {get; set;}

    private int roundNumber = 0;
    public bool roundActive {
        get {return activeChickens.Count > 0;}
    }

    [SerializeField]
    private TextMeshProUGUI roundText;

    [SerializeField]
    private GameObject nextRoundButton;

    private List<GameObject> activeChickens = new List<GameObject>();

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
        if (PauseMenu.paused)
        {
            return;
        }
        this.ClickedTower = tower;
        levelManager.Placing = true;
        hover.Activate(tower.Sprite);
    }

    public void StartRound() {
        roundNumber++;
        roundText.text = string.Format("Round {0}", roundNumber);
        SpawnRound();
        // TODO: uncomment this when implemented
        //nextRoundButton.SetActive(false);
    }

    // TODO: need to call this when chicken is killed or exits
    public void RemoveChicken(GameObject chicken) {
        activeChickens.Remove(chicken);
        if (!roundActive) {
            nextRoundButton.SetActive(true);
        }
    }

    private IEnumerator spawn(string s) {
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == 'a') {
                activeChickens.Add(Pool.GetObject("Chicken"));
            } else if (s[i] == 'b') {
                activeChickens.Add(Pool.GetObject("Cock"));
            } else {
                yield return new WaitForSeconds(s[i] - '0');
            }
        }
        // activeChickens.Add(Pool.GetObject("Chicken"));
        // yield return new WaitForSeconds(1);
        // activeChickens.Add(Pool.GetObject("Chicken"));
    }

    private void SpawnRound() {
        string s = "";
        switch (roundNumber) {
            case 1:
                s = "a2a2a2a2a";
                break;
            case 2:
                s = "a1a1a1a1a1a1a1a";
                break;
            case 3:
                s = "b2b2b2b2b";
                break;
            case 4:
                s = "b2b2b2b2b1a1a1a1a1a";
                break;
            case 5:
                s = "b1b1b1b1b1b1b1b1b1b";
                break;
            case 6:
                s = "aaaaaaaaaa";
                break;
        }
        StartCoroutine(spawn(s));
    }
}
