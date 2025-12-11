using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bunny player = collision.gameObject.GetComponent<Bunny>();
           
                player.health += 1;
                Destroy(gameObject);
                gameManager = FindFirstObjectByType<GameManager>();
                gameManager.UpdateBunnyHealth(player.health);
                SoundManager.Instance.PlaySFX("CHERRY");
            
        }
    }
}
