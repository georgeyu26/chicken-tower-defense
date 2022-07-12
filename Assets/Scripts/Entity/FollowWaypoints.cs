using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    // Target path
    public GameObject[] waypoints;
    private int _currentWaypoint;

    // Variables about the chicken body
    private Rigidbody2D _body;
    private CircleCollider2D _collider;
    public float maxSpeed;
    public float brakingFactor;
    
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        // Change waypoint if last waypoint was reached
        if (Vector2.Distance(transform.position, waypoints[_currentWaypoint].transform.position) < 
            _collider.radius)
        {
            _currentWaypoint++;
            _currentWaypoint %= waypoints.Length;
        }
        
        // Calculate what direction the next waypoint is at
        Vector2 toFace = waypoints[_currentWaypoint].transform.position - transform.position;
        toFace.Normalize();
        
        // Calculate the actual velocity of the chicken (factoring in stopping speed, etc.)
        var newHeading = maxSpeed * toFace - 
                         (1 + brakingFactor * 1.0f/180 * Vector2.Angle(_body.velocity, toFace)) * _body.velocity;
        
        // Move chicken towards current facing direction (and don't ever rotate the rigidbody)
        if (Time.timeScale != 0) _body.AddForce(newHeading, ForceMode2D.Force);
        transform.rotation = new Quaternion(0,0,0,0);
    }
}
