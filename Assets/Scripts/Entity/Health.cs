using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public GameObject deathAnimation;
    private Tilemap map;

    [SerializeField]
    public Tile goodTile;

    private void Start()
    {
        currentHealth = maxHealth;
        map = GameObject.Find("Ground").GetComponent<Tilemap>();;
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
            Vector3 objectPos = gameObject.transform.position;
            Vector3Int tilePos = Vector3Int.FloorToInt(objectPos);
            map.SetTile(tilePos, goodTile);
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
