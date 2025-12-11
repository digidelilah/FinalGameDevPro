using UnityEngine;


public class Enemies : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] points;

    private int i;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.25f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        spriteRenderer.flipX = (transform.position.x - points[i].position.x) < 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bunny player = collision.gameObject.GetComponent<Bunny>();
            if (gameObject.tag == "Damage")
            {
                animator.Play("Slug_Death");
                animator.Play("Bee_Death");
                Destroy(gameObject, 0.5f);
                player.health += 1; 
            }
        }
    }
}