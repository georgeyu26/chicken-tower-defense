using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public GameObject deathAnimation;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            // Only create death animation if it was passed in
            GameObject deathAnim = null;
            if (deathAnimation) 
            {
                deathAnim = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

            if (deathAnim)
            {
                Destroy(deathAnim, 0.5f);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
