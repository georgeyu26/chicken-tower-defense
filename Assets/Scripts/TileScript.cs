using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScript : MonoBehaviour
{
    private LevelManager levelManager;
    private Vector3Int prevPos;
    private Tile prevTile;
    
    [SerializeField]
    public Tile highlightTile;

    [SerializeField]
    private Tilemap map;

    private void Awake(){
        levelManager = FindObjectOfType<LevelManager>();
    }

    // public Point GridPosition {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = map.WorldToCell(mousePosition);
        prevPos = gridPos;
        prevTile = map.GetTile<Tile>(gridPos);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HoverTile(mousePosition);

    }


    private void HoverTile(Vector2 mousePos){
        Vector3Int gridPos = map.WorldToCell(mousePos);
        if (gridPos != prevPos){
            map.SetTile(prevPos, prevTile);
 
            if (levelManager.GetTileValid(mousePos) != 1){
                prevPos = gridPos;
                prevTile = map.GetTile<Tile>(gridPos);
                map.SetTile(gridPos, highlightTile);
            }
        }
       
    }
}
