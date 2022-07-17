using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 dragOrigin; 
    public BoxCollider2D boundBox;
    public Vector3 minBounds; 
    public Vector3 maxBounds; 

    public float zoomMin = 2; 
    public float zoomMax = 6; 


    private float halfHeight;
    private float halfWidth; 


    // Start is called before the first frame update
    void Start()
    {
       minBounds = boundBox.bounds.min;
       maxBounds = boundBox.bounds.max;
    }

    // Update is called once per frameW
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if(Input.touchCount == 2){ // For touch devices
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            float prevMagnitude = (touch1PrevPos - touch2PrevPos).magnitude;
            float curMagnitude = (touch1.position - touch2.position).magnitude;

            float magnitudeDiff = curMagnitude - prevMagnitude;

            zoom(magnitudeDiff * 0.01f);
        } else if(Input.GetMouseButton(0) && !FindObjectOfType<ShopManager>().showShop){
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = dragOrigin - diff; 

            Camera.main.transform.position = ClampCamera(Camera.main.transform.position + direction);
            //Camera.main.transform.position += direction;

            //Camera.main.transform.position += clampedDirection.ClampedMagnitude(direction, min(clampedX,clampedY));
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));


        
    }

    void zoom(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
    }

    private Vector3 ClampCamera(Vector3 direction){ //making sure that the camera is within the bounds of the map
            halfHeight = Camera.main.orthographicSize;
            halfWidth = halfHeight * Screen.width / Screen.height;
            float clampedX = Mathf.Clamp(direction.x, minBounds.x + halfWidth,  maxBounds.x - halfWidth);
            float clampedY =  Mathf.Clamp(direction.y, minBounds.y + halfHeight,  maxBounds.y - halfHeight);
            return new Vector3(clampedX, clampedY, direction.z);
    }
}
