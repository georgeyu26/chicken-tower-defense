using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class LPCHealth : Health
{
    protected override SpriteRenderer GetSpriteRenderer()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }
    
    // TODO: This should call the GameOver screen
    protected override void HandleGameStateInteractions() {}

    // LPC doesn't need to interact with map since its destruction is end of game anyway
    protected override void InitializeMapComponents() {}
    
}
