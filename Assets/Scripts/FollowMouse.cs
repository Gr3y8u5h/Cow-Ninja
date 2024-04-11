using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    TrailRenderer trailRenderer;
    bool isFlipped;

    private void Start()
    {
        Cursor.visible = false;
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void Update()
    {

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
        FlipSword();
        SwordOn();
    }

    void SwordOn()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Trail Renderer Can operate");
            trailRenderer.enabled = true;
            
        }
        else
        {
            trailRenderer.enabled = false;
        }
    }
    
    void FlipSword()
    {
        if (transform.position.x > 0f && isFlipped)
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
            isFlipped = false;
        }
        if (transform.position.x < 0f && !isFlipped)
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
            isFlipped = true;
        }
    }
}
