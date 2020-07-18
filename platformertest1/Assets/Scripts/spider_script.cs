using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_script : MonoBehaviour
{
    public float speed;
    public float checkDistance;
    public float checkRadius;
    private bool movingRight = false;
    private bool touchingWall;
    public Transform groundDetection;
    public Transform wallDetection;
    public Rigidbody2D rb;
    public LayerMask whatIsGround;  

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, checkDistance, whatIsGround);
        touchingWall = Physics2D.OverlapCircle(wallDetection.position, checkRadius, whatIsGround);

        if (touchingWall == true)
        {
            speed = speed * -1;
            if (movingRight == true)
            {
                Vector2 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
                movingRight = false;
            }
            else
            {
                Vector2 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
                movingRight = false;
            }
        }
        else if (groundInfo.collider == false)
        {
            speed = speed * -1;
            if(movingRight == true)
            {
                Vector2 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
                movingRight = false;
            }
            else
            {
                Vector2 Scaler = transform.localScale;
                Scaler.x *= -1;
                transform.localScale = Scaler;
                movingRight = false;
            }
        } 
    }
}
