using UnityEngine;

public class Bunny : MonoBehaviour
{
    public int health = 100; // <----------------------------new by D

    public float moveSpeed = 4f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;


    private SpriteRenderer spriteRenderer; // <----------------------------new by D
    private new Rigidbody2D rigidbody;
    private bool isGrounded;

    private Animator animator;

    public int extraJumpsValue = 1;
    private int extraJumps;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<spriteRenderer>(); // <----------------------------new by D

        extraJumps = extraJumpsValue;
    }


    void Update()
    {

        float moveInput = Input.GetAxis("Horizontal");
        rigidbody.linearVelocity = new Vector2(moveInput * moveSpeed, rigidbody.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            //moveInput(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //moveInput(Vector3.right);
        }

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
            else if (extraJumps >0)
            {
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
                extraJumps--;
            }
        }


        // --- Ground check ---
        // Create an invisible circle at the GroundCheck position.
        // If this circle overlaps any collider on the "Ground" layer, player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // --- Jump ---
        // If player is grounded AND the Jump button (Spacebar by default) is pressed:
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Set vertical velocity to jumpForce (launch upward).
            // Horizontal velocity stays the same.
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
        }


        SetAnimation(moveInput);
    }
    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Walk");
            }
        }
        else
        {
            if (rigidbody.linearVelocityY > 0)
            {
                animator.Play("Player_Jump");
            }
            else
            {
                animator.Play("Player_Fall");
            }
        }
    }
    /*
    // detect collision with the player // <----------------------------new by D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the colliding object is tagged "Player"
        if (collision.gameObject.CompareTag("Player"))
        { 
            // access the playerhealth and apply damage
            collision.gameObject.GetComponent<Player .............health
        }
    }
    */
}
