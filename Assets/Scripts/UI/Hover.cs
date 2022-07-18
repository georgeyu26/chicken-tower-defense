using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private SpriteRenderer rangeSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        //Get range sprite on hover
        this.rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused)
        {
            return;
        }
        FollowMouse();
    }

    private void FollowMouse() {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(Sprite sprite) {
        this.spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
        //rangeSpriteRenderer.enabled = true;
    }

    public void Deactivate() {
        spriteRenderer.enabled = false;
        rangeSpriteRenderer.enabled = false;
    }
}
