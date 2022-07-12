using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TowerHealth : Health
{
    private Tilemap _map;

    [SerializeField] public Tile goodTile;
    
    protected override void InitializeMapComponents()
    {
        _map = GameObject.Find("Ground").GetComponent<Tilemap>();
    }

    protected override void HandleGameStateInteractions()
    {
        Vector3Int tilePos = Vector3Int.FloorToInt(gameObject.transform.position);
        _map.SetTile(tilePos, goodTile);
    }
    protected override SpriteRenderer GetSpriteRenderer()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }
    
}
