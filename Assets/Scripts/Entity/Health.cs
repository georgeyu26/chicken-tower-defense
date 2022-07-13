using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public GameObject deathAnimation;

    protected SpriteRenderer sp;
    
    private void Start()
    {
        currentHealth = maxHealth;
        sp = GetSpriteRenderer();
        InitializeMapComponents();
    }
    
    // Method called externally only
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateVisual();
        
        // What follows needs only be executed if object is dead
        if (currentHealth > 0) return;
        
        // Only create death animation if it was passed in
        GameObject deathAnim = null;
        if (deathAnimation) deathAnim = Instantiate(deathAnimation, transform.position, Quaternion.identity);
        HandleGameStateInteractions();
        Destroy(gameObject);

        if (deathAnim) Destroy(deathAnim, 0.5f);
    }
    
    protected abstract void InitializeMapComponents();
    protected abstract void UpdateVisual();
    protected abstract void HandleGameStateInteractions();
    protected abstract SpriteRenderer GetSpriteRenderer();
}
