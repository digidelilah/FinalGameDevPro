using UnityEngine;

public class CollectibleCarrot : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bunny player = collision.gameObject.GetComponent<Bunny>();
            player.carrot += 1;
            Destroy(gameObject);
        }
    }
}