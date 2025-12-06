using Unity.Collections;
using UnityEngine;

public class NextLvl : MonoBehaviour
{
    public string nextLvlName;
    public void LoadNextLvl()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLvlName);
       
        Time.timeScale = 1;
    }
}
