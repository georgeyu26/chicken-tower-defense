using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition) ;
            float walkingSpeed = dataFromTiles[clickedTile].movingSpeed;
            print("Walking speed on " + clickedTile + ": " +  walkingSpeed );
        }
        
    }

    private void Awake(){
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var tileData in tileDatas){
            foreach(var tile in tileData.tiles){
                dataFromTiles.Add(tile, tileData);
            }
        }

        // Add logic to give each tile a point? and use Point.cs
    }

    // public float GetTileData(vector2 worldPosition){
    //     Vector3Int gridPos = map.WorldToCell(worldPosition);
    //     TileBase tile = map.GetTile(gridPos);

    // }

    public int GetTileValid(Vector2 worldPosition){
        Vector3Int gridPos = map.WorldToCell(worldPosition);
        TileBase tile = map.GetTile(gridPos);
        int buyTower = 0;
        
        if(dataFromTiles.ContainsKey(tile)){
            buyTower = dataFromTiles[tile].buyTower;
        }
        return buyTower;
    }
}
