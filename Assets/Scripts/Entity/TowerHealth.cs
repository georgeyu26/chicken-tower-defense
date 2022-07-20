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

    public override void UpdateVisual()
    {
        // Change hue of object tower on how much damage it has taken (gets redder as HP drops)
        sp.color = new Color(
            1,
            (float)currentHealth / maxHealth,
            (float)currentHealth / maxHealth);
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
