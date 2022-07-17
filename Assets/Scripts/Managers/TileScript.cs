using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    private LevelManager levelManager;
    private GameManager gameManager;
    private Vector3Int prevPos;
    private Tile prevTile;

    private int id;
    
    [SerializeField]
    public Tile badTile;

    [SerializeField]
    public Tile goodTile;

    [SerializeField]
    public Tile usedTile;

    [SerializeField]
    private Tilemap map;

    private void Awake(){
        levelManager = FindObjectOfType<LevelManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // public Point GridPosition {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        id = 0;

        if (PauseMenu.paused)
        {
            return;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = map.WorldToCell(mousePosition);
        prevPos = gridPos;
        prevTile = map.GetTile<Tile>(gridPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused)
        {
            return;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (levelManager.Placing == true){
            if (Input.GetMouseButtonUp(0)){
                PlaceTower(mousePosition);
            } else {
                HoverTile(mousePosition);
            }
        }
        else{
            if (Input.GetMouseButtonUp(0)){
                Vector3Int gridPos = map.WorldToCell(mousePosition);
                Tile currTile = map.GetTile<Tile>(gridPos);
                
                if(currTile != usedTile){
                    if(gameManager.LastTower != null){
                        TowerMenu last = (TowerMenu) gameManager.LastTower.GetComponent(typeof(TowerMenu));
                        last.Toggle();
                    }
                    
                    gameManager.LastTower = null;
                }
            }
        }
    }

    private void HoverTile(Vector2 mousePos){
        Vector3Int gridPos = map.WorldToCell(mousePos);
        if (gridPos != prevPos){
            map.SetTile(prevPos, prevTile);
            if (levelManager.GetTileValid(mousePos) != 1 || map.GetTile<Tile>(gridPos) == usedTile){
                prevPos = gridPos;
                prevTile = map.GetTile<Tile>(gridPos);
                map.SetTile(gridPos, badTile);
            } else {
                prevPos = gridPos;
                prevTile = map.GetTile<Tile>(gridPos);
                map.SetTile(gridPos, goodTile);
            }
        }
       
    }

    private void PlaceTower(Vector2 mousePos){
        Vector3Int gridPos = map.WorldToCell(mousePos);
        if (map.GetTile<Tile>(gridPos) == goodTile){
            levelManager.Placing = false;
            gameManager.Hover.Deactivate();
            GameObject tower = (GameObject) Instantiate(gameManager.ClickedTower.TowerPrefab, gridPos, Quaternion.identity);

            tower.name += id++;

            map.SetTile(gridPos, usedTile);
            // Use offscreen tile to reset
            prevPos = new Vector3Int(-11, -5, 0);

            gameManager.Currency -= gameManager.ClickedTower.Cost;
        } else {
            levelManager.Placing = false;
            map.SetTile(prevPos, prevTile);
            gameManager.Hover.Deactivate();
        }
    }
    public void LoadTower(GameObject tower)
    {
        map.SetTile(Vector3Int.FloorToInt(tower.transform.position), usedTile);
    }
}
