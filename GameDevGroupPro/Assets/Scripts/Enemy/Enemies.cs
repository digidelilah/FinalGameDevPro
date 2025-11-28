using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 1f;
    private Rigidbody2D rb;
    private Vector2 startPos;
    private int direction = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            direction *= -1;
        }
    }
}
