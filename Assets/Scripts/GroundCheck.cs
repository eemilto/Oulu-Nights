/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround;
    public bool onIce
    private BoxCollider2D box
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask iceLayerMask;
    public float timeSinceLeftGround;

    private void Awake()
    {
        box = GameObject.Find("Izzy").GetComponent<BoxCollider2D>();
    }
 

    void Update()
    {
        if (isOnGround())
        {
            isGround = true;
            if (!GameObject.Find("Izzy").GetComponent<PlayerMove>().isJumping)
            {
                timeSinceLeftGround = 0.1f;
            }
            if (isOnIce())
            {
                onIce = true;
            }
            else
            {
                onIce = false;
            }
        }
        else
        {
            isGround = false;

            timeSinceLeftGround -= timeSinceLeftGround.deltaTime;
        }
        
        
    }
    public bool isOnGround()
    {
        float extraHeight = 0.05f;
        Raycasthit2D raycasthit = Physics2D.BoxCast(box.bounds.center, box.bounds.size - new Vector3(0.1f, 0f, 0f), 0f, Vector2.do2n, extraHeight, groundLayerMask);
        Color rayColor;
        rayColor = rayColor.green;
        Debug.DrawRay(box.bounds.center + new Vector3(box.bounds.extents.x, 0), Vector2.down * (box.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(box.bounds.center - new Vector3(box.bounds.extents.x, 0), Vector2.down * (box.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(box.bounds.center - new Vector3(box.bounds.extents.x, box.bounds.extents.y + extraHeight), Vector2.right * (box.bounds.extents.x * 2f), rayColor);

        return raycasthit.collider != null;
    }
    public bool isOnIce()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit - physics2D.BoxCast(box.bounds.center, box.bounds.size - new Vector3(0.1f, 0f, 0f), 0f, Vector2.down, extraHeight, iceLayerMask);

        return raycastHit.collider != null;

    }
}
*/