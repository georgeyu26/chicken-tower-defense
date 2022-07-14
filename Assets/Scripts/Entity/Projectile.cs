using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _projectile;
    
    public float speed;
    public int projectileStrength;

    public string toHit;
    public GameObject hitAnimation;

    private void Awake()
    {
        _projectile = transform.GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _projectile.AddForce(speed * transform.up, ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only hit the item this projectile has been assigned to hit
        if (!collision.gameObject.CompareTag(toHit)) return;
        
        // Only create explosion animation if it was passed in
        GameObject explosion = null;
        if (hitAnimation) 
        {
            explosion = Instantiate(
                hitAnimation, 
                1.0f/2 * (transform.position + collision.transform.position), 
                Quaternion.identity);
        }
        
        // Calculate type effectiveness: if no effectiveness is found, just presume normal effectiveness
        // NOTE: this try-catch _should technically_ never catch since types are enums
        var multiplier = 1.0f;
        try
        {
            multiplier = Typing.multiplier(
                this.GetComponent<Typing>().type, 
                collision.gameObject.GetComponent<Typing>().type);
        }
        catch { /* ignored */ }

        // Damage the victim
        collision.gameObject.SendMessage("TakeDamage", multiplier * projectileStrength);
        
        // Get rid of the bullet since it has collided with target and explosion animation
        Destroy(gameObject);
        if (explosion) Destroy(explosion, 0.5f);
    }
}
