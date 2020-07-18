using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_script : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    private bool touchingUp;
    private bool touchingDown;
    private bool goingUp = true;
    public Transform topCheck;
    public Transform bottomCheck;
    public Rigidbody2D rb;
    public LayerMask whatIsGround;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, speed);

        touchingUp = Physics2D.OverlapCircle(topCheck.position, checkRadius, whatIsGround);
        touchingDown = Physics2D.OverlapCircle(bottomCheck.position, checkRadius, whatIsGround);

        if (goingUp == true)
        {
            if (touchingUp == true)
            {
                goingUp = false;
                speed = speed * -1;
            }
        }
        else
        {
            if (touchingDown == true)
            {
                goingUp = true;
                speed = speed * -1;
            }
        }
    }
}
