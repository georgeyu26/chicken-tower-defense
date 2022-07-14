using UnityEngine;
using UnityEngine.SceneManagement;

public class LPCHealth : Health
{
    protected override SpriteRenderer GetSpriteRenderer()
    {
        return gameObject.GetComponent<SpriteRenderer>();
    }
    
    protected override void UpdateVisual()
    {
        FindObjectOfType<GameManager>().LFPHealth = currentHealth > 0 ? currentHealth : 0;
        Handheld.Vibrate();
    }

    protected override void HandleGameStateInteractions()
    {
        for (int i = 0; i < 20; i++)
        {
            Handheld.Vibrate();
        }
        SceneManager.LoadScene("GameOver");
    }

    // LPC doesn't need to interact with map since its destruction is end of game anyway
    protected override void InitializeMapComponents() {}
    
}
