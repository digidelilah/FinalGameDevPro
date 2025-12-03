using UnityEngine;

public class CollectibleCarrot : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bunny player = collision.gameObject.GetComponent<Bunny>();
            if(gameObject.tag == "Carrot")
            {
                player.carrot += 1;
                Destroy(gameObject);
                SoundManager.Instance.PlaySFX("CARROT");
            }
            if (gameObject.tag == "Gem")
            {
                player.carrot += 5;
                Destroy(gameObject);
                SoundManager.Instance.PlaySFX("GEM");
            }

        }
    }
}