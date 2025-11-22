using UnityEngine;

public class Bunny : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private new Rigidbody2D rigidbody;
    private bool isGrounded;

    private Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rigidbody.linearVelocity = new Vector2(moveInput * moveSpeed, rigidbody.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
            {
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpForce);
            }

        SetAnimation(moveInput);
    }
    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if(moveInput == 0)
            {
                animator.Play("BunnyIdle");
            }
            else
            {
                animator.Play("walkCycle");
            }
        }
        else
        {
           if(rigidbody.linearVelocityY > 0)
            {
                animator.Play("Jump");
            }
        }
    }
}
