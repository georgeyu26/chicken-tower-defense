using UnityEngine;

public class ChickenHealth : Health
{
    protected override SpriteRenderer GetSpriteRenderer()
    {
        return gameObject.GetComponentsInChildren<SpriteRenderer>()[1];
    }
    
    protected override void UpdateVisual()
    {
        // Change hue of chicken depending on how much damage it has taken (gets redder as HP drops)
        sp.color = new Color(
            1,
            (float)currentHealth / maxHealth,
            (float)currentHealth / maxHealth);
    }
    
    // Do nothing, chickens do not interact with tilemap (yet)
    protected override void InitializeMapComponents() {}
    protected override void HandleGameStateInteractions() {}
}
