using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public GameObject deathAnimation;

    private SpriteRenderer _sp;
    
    private void Start()
    {
        currentHealth = maxHealth;
        _sp = GetSpriteRenderer();
        InitializeMapComponents();
    }

    private void Update()
    {
        // Change hue of object depending on how much damage it has taken (gets redder as HP drops)
        _sp.color = new Color(
            1,
            (float)currentHealth / maxHealth,
            (float)currentHealth / maxHealth);

        // What follows needs only be executed if object is dead
        if (currentHealth > 0) return;
        
        // Only create death animation if it was passed in
        GameObject deathAnim = null;
        if (deathAnimation) deathAnim = Instantiate(deathAnimation, transform.position, Quaternion.identity);
        HandleGameStateInteractions();
        Destroy(gameObject);

        if (deathAnim) Destroy(deathAnim, 0.5f);
    }

    // Method called externally only
    public void TakeDamage(int damage) { currentHealth -= damage; }
    
    protected abstract void InitializeMapComponents();
    protected abstract void HandleGameStateInteractions();
    protected abstract SpriteRenderer GetSpriteRenderer();
}
