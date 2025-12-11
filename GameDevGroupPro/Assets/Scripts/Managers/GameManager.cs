using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject HealthFull;
    public GameObject HealthHalf;
    public GameObject HealthOne;
    public GameObject HealthDead;

    public void UpdateBunnyHealth(int health)
    {
        HealthFull.SetActive(false);
        HealthHalf.SetActive(false);
        HealthOne.SetActive(false);
        HealthDead.SetActive(false);

        if (health == 3)
        {
            HealthFull.SetActive(true);
        }
        else if (health == 2)
        {
            HealthFull.SetActive(false);
            HealthHalf.SetActive(true);
        }
        else if (health == 1)
        {
            HealthOne.SetActive(true);
        }
        else
            HealthDead.SetActive(true);

    }

}
