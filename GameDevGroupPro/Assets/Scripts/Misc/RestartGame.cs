using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        // CHANGE THE SCENE NAME TO WHICHEVER YOU WANT TO LOAD ^^
        Time.timeScale = 1;
    }
}
