using UnityEngine;
using TMPro;

public class CollectibleCarrot : MonoBehaviour
{
    private TextMeshProUGUI pointText;

    private void Start()
    {
        pointText = GameObject.FindWithTag("pointText").GetComponent<TextMeshProUGUI>();
    }

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
                pointText.text = player.carrot.ToString();
            }
            if (gameObject.tag == "Gem")
            {
                player.carrot += 5;
                Destroy(gameObject);
                SoundManager.Instance.PlaySFX("GEM");
                pointText.text = player.carrot.ToString();
            }

        }
    }
}