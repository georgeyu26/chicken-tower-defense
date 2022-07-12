using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class ChickenHealth : Health
{
    protected override SpriteRenderer GetSpriteRenderer()
    {
        return gameObject.GetComponentsInChildren<SpriteRenderer>()[1];
    }
    
    // Do nothing, chickens do not interact with tilemap (yet)
    protected override void InitializeMapComponents() {}
    protected override void HandleGameStateInteractions() {}
    
}
