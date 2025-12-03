using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView; // <--------------------------new by D


public class Bunny : MonoBehaviour
{
    public int carrot;
    public int health = 100;

    // --- Jump variables ---
    public float jumpForce = 8f;           // Base jump force (vertical speed)
    public int extraJumpsValue = 1;        // How many extra jumps allowed (1 = double jump, 2 = triple jump)
    private int extraJumps;                // Counter for jumps left

    public float moveSpeed = 4f;
    
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    //public Image healthImage; // <--------------------------new by D


    private SpriteRenderer spriteRenderer; 
    private new Rigidbody2D rigidbody;
    private bool isGrounded;

    private Animator animator;

    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

        //healthImage.fillAmount = health / 100f;// <--------------------------new by D

        // Reset extra jumps when grounded
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // --- Jump & Double Jump ---
        // If Space is pressed:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                // Normal jump
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
                SoundManager.Instance.PlaySFX("JUMP");
            }
            else if (extraJumps > 0)
            {
                // Extra jump (double or triple depending on extraJumpsValue)
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
                extraJumps--; // Reduce available extra jumps
                SoundManager.Instance.PlaySFX("JUMP");
            }
        }


        // --- Ground check ---
        // Create an invisible circle at the GroundCheck position.
        // If this circle overlaps any collider on the "Ground" layer, player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // --- Jump ---
        // If player is grounded AND the Jump button (Spacebar by default) is pressed:
        /*if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Set vertical velocity to jumpForce (launch upward).
            // Horizontal velocity stays the same.
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
        }*/


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

    // detect collision with the player 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            health -= 1;
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
            StartCoroutine(BlinkRed());
        }

        if (health <= 3)
        {
            
        }
        else if (health <= 2)
        {

        }
        else if (health <= 1 )
        {

        }
        else 
        {
            Die();
        }
        
    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        animator.Play("Player_Hurt");
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    
    private void Die()
    {
        // UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); // may be renamed to our own scenes for testing
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
    }

   
}
