using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Transform ShieldPoint;
    
    public float speed = 100f;
    public float ladderSpeed = 100f;
    public float jumpForce = 100f;
    private bool facingRight = true;
    public Vector2 shieldSize = new Vector2(1f, 2f);
    public float shield_Size = 2f;

    private bool isGrounded;
    private bool isClimbing;
    public Transform groundCheck;
    public float checkRadius;
    public float ladderDistance;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;

    public Transform attackPoint;
    public Vector2 StillPoint = new Vector2(-0.43f, -0.2f);
    public Vector2 MovingPoint = new Vector2(-0.53f, -0.2f);
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    public int ShieldDamage = 1;
    public int shieldUpForce = 6;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isClimbing)
        {
            if (isGrounded == true)
            {
                Attack();
            }
            else
            {
                ShieldAttack();
            }
        }
        
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Mathf.Abs(rb.velocity.x) > 1f)
        {
            attackPoint.localPosition = MovingPoint;
        }
        else
        {
            attackPoint.localPosition = StillPoint;  
        }

        if (isGrounded == true)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
    }
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

    void Attack()
    {
        animator.SetTrigger("IsAttacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //play attack animation
        foreach (Collider2D enemy in hitEnemies)
        {   
            enemy.GetComponent<enemy>().TakeDamage(attackDamage);
            //Destroy(enemy.gameObject);
            Debug.Log("player smacked enemy");
        } 
    }

    void ShieldAttack()
    {                                      
        animator.SetTrigger("IsAttacking");

        StartCoroutine(ShieldAttackCoroutine());

        //Collider2D[] hitStuff = Physics2D.OverlapBoxAll(ShieldPoint.position, shieldSize, enemyLayers);
        //Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(ShieldPoint.position, shieldSize, enemyLayers);
        //why does overlapboxall not work?
       

    }

    private IEnumerator ShieldAttackCoroutine()
    {
        bool done = false;
        while (!done)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ShieldPoint.position, shield_Size, enemyLayers);
            
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<enemy>().TakeDamage(attackDamage);
                Debug.Log("player smacked something");
            }

            if (hitEnemies.Length > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, shieldUpForce);
                done = true;
            }
            else if (isGrounded) done = true;
            else
            {
                yield return null;
            }
        }
    }
}
