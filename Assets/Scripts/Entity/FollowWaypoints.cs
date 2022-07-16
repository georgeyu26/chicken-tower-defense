using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    // Target path
    public Vector2[] waypoints;
    private int _currentWaypoint;

    // Variables about the chicken body
    private Rigidbody2D _body;
    private CircleCollider2D _collider;
    public float maxSpeed;
    public float brakingFactor;
    public float acceleration;
    
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        // Change waypoint if last waypoint was reached
        if (Vector2.Distance(transform.position, waypoints[_currentWaypoint]) < _collider.radius)
        {
            _currentWaypoint++;
            _currentWaypoint %= waypoints.Length;
        }
        
        // Calculate what direction the next waypoint is at
        var toFace = waypoints[_currentWaypoint] - (Vector2)transform.position;
        toFace.Normalize();
        
        // Calculate the actual velocity of the chicken (factoring in stopping speed, etc.)
        var accelerationFactor = _body.velocity.magnitude < maxSpeed/2     ? acceleration  : 0;
        var swingAroundFactor  = Vector2.Angle(_body.velocity, toFace) > 5 ? brakingFactor : 0;
        
        var newHeading = maxSpeed * (1 + accelerationFactor) * toFace - (1 + swingAroundFactor) * _body.velocity;
        
        // Move chicken towards current facing direction (and don't ever rotate the rigidbody)
        if (Time.timeScale != 0) _body.AddForce(newHeading, ForceMode2D.Force);
        transform.rotation = new Quaternion(0,0,0,0);
    }
}
