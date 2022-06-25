using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    public float radiusOfAttack;
    public float sleepTime = Mathf.Infinity;
    
    public string enemyLayer;
    public GameObject bulletToFire;

    private float _cooldownTime;
    
    // Update is called once per frame
    private void Update()
    {
        // Check that the turret is not in cooldown (if it is, don't do anything)
        if (_cooldownTime > 0)
        {
            _cooldownTime -= Time.deltaTime;
            return;
        }
        
        // Get the first enemy within the radius (note that this means it gets the _closest_ enemy)
        var enemy = Physics2D.CircleCast(
            transform.position, radiusOfAttack, Vector2.zero, 
            Mathf.Infinity, LayerMask.GetMask(enemyLayer));

        // Check if there is an enemy in radius of attack, otherwise return
        if (!enemy) return;
        
        // Calculate the trajectory of bullet: have to flatten z-axis or bullet will move in 3D
        var bulletHeading = enemy.transform.position - transform.position;

        // Create new bullet object
        var bullet = Instantiate(bulletToFire, transform.position, Quaternion.identity);
        bullet.transform.right = bulletHeading;
        
        // Have turret sleep for X amount of time
        _cooldownTime += sleepTime;
    }
}
