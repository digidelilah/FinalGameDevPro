using Unity.Collections;
using UnityEngine;

public class NextLvl : MonoBehaviour
{
    public string nextLvlName;
    public int nextLevelValue;
    public void LoadNextLvl()
    {
        PlayerPrefs.SetInt("LevelReached", nextLevelValue);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLvlName);
       
        Time.timeScale = 1;
    }
}
