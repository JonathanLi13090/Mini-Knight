using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 100f;
    public float ladderSpeed = 100f;
    public float jumpForce = 100f;
    private bool facingRight = true;

    private bool isGrounded;
    private bool isClimbing;
    public Transform groundCheck;
    public float checkRadius;
    public float ladderDistance;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;

    public void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderDistance, whatIsLadder);

        if(hitInfo.collider != null) {
            if (Input.GetKey("w")) {
                isClimbing = true;
            }
        } else {
            isClimbing = false;
        }

        if(isClimbing == true) {
            if (Input.GetKey("w")) {
                rb.velocity = new Vector2(rb.velocity.x, ladderSpeed);
                rb.gravityScale = 0;
            }else if (Input.GetKey("s")){
                rb.velocity = new Vector2(rb.velocity.x, -ladderSpeed);
                rb.gravityScale = 0;
            }else{
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        } else {
            rb.gravityScale = 5;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKey("w") && isGrounded == true){
            rb.velocity = new Vector2(0, jumpForce);
        }
        if (Input.GetKey("d")){
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }else if (Input.GetKey("a")){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (facingRight == false && Input.GetKey("a")){
            Flip();
        }else if (facingRight == true && Input.GetKey("d")){
            Flip();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
