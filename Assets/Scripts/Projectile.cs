using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _projectile;

    public float speed;

    public GameObject hitAnimation;
    
    private void Awake()
    {
        _projectile = transform.GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _projectile.AddForce(speed * transform.right, ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var explosion = Instantiate(
            hitAnimation, 1.0f/2 * (transform.position + collision.transform.position), Quaternion.identity);
        
        Destroy(collision.gameObject);
        Destroy(gameObject);
        
        Destroy(explosion, 0.5f);
    }
}
