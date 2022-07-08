using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer mySpriteRenderer;
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select() {
        mySpriteRenderer.enabled = !mySpriteRenderer.enabled;
    }
    public void Disable() {
        mySpriteRenderer.enabled = false;
    }
}
