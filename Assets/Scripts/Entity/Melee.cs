using UnityEngine;

public class Melee : MonoBehaviour
{
    public float radiusOfAttack;
    public float attackStrength;
    public float sleepTime = Mathf.Infinity;

    public string enemyLayer;
    public GameObject meleeAnimation;

    private float _cooldownTime;
    private Renderer _renderer;
    
    private void Awake()
    {
        _renderer = transform.GetComponent<Renderer>();
    }

    private void Update()
    {
        // Check that the melee-er is not in cooldown (if it is, don't do anything)
        if (_cooldownTime > 0)
        {
            _cooldownTime -= Time.deltaTime;
            return;
        }

        var spriteCenter = _renderer.bounds.center;
        
        // Get the first enemy within the radius (note that this means it gets the _closest_ enemy)
        var enemies = Physics2D.OverlapCircleAll(spriteCenter, radiusOfAttack, LayerMask.GetMask(enemyLayer));

        // Check if there is any enemy in radius of attack, otherwise return
        if (enemies.Length == 0) return;
        
        // Calculate the trajectory of bullet: have to flatten z-axis or bullet will move in 3D
        var attackHeading = Vector2.zero;
        foreach (var enemy in enemies)
        {
            attackHeading += (Vector2)(enemy.transform.position - spriteCenter);
            enemy.gameObject.SendMessage("TakeDamage", attackStrength);
        }

        attackHeading /= enemies.Length;

        // Create new bullet object
        var meleeSwing = Instantiate(meleeAnimation, spriteCenter, Quaternion.identity);
        meleeSwing.transform.right = attackHeading;
        meleeSwing.GetComponent<Rigidbody2D>().AddForce(attackHeading * 2, ForceMode2D.Impulse);
        Destroy(meleeSwing, 0.5f);
        
        // Have melee-er sleep for X amount of time
        _cooldownTime += sleepTime;
    }
    
    
    
}

