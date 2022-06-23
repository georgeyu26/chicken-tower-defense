using UnityEngine;

public class FaceRightDirection : MonoBehaviour
{
    private SpriteRenderer _sp;
    private Rigidbody2D _rb;
    
    public float rotationSpeed = 0.5f;
    public float rotationLimit = 3;

    // Quick helper function 
    private bool Between(float number, float min, float max)
    {
        return number >= min && number <= max;
    }
    
    private void Awake()
    {
        _rb = transform.parent.GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Have the chicken face the correct direction (left or right)
        _sp.flipX = _rb.velocity.x > 0;
        
        // Have the chicken waddle a bit as it walks
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
        
        if (Between(transform.eulerAngles.magnitude, rotationLimit, 180) && rotationSpeed > 0 ||
            Between(transform.eulerAngles.magnitude, 180, 360 - rotationLimit) && rotationSpeed < 0)
        {
            rotationSpeed *= -1;
        } 
    }
}
