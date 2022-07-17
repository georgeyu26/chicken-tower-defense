using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private Camera cam;

    [SerializeField] private float zoomStep, minCam, maxCam;  
    private Vector3 dragOrigin;
    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 diff = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += diff;
        }
    }

    public void ZoomIn()
    {
        
    }
    public void ZoomOut()
    {
        
    }
    
 
}

