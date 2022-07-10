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
    
    [SerializeField]
    public Tile badTile;

    [SerializeField]
    public Tile goodTile;

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
            }
            HoverTile(mousePosition);
        }
    }

    private void HoverTile(Vector2 mousePos){
        Vector3Int gridPos = map.WorldToCell(mousePos);
        if (gridPos != prevPos){
            map.SetTile(prevPos, prevTile);
 
            if (levelManager.GetTileValid(mousePos) != 1){
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
            GameObject tower = (GameObject) Instantiate(gameManager.ClickedTower.TowerPrefab, gridPos, Quaternion.identity);
            levelManager.Placing = false;
            map.SetTile(prevPos, prevTile);
            gameManager.Hover.Deactivate();
        }
    }
}
