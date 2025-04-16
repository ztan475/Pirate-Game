using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OpenLevelSelect()
    {
        Time.timeScale = 1f; // in case you're in pause mode
        SceneManager.LoadScene("LevelSelect"); // match the scene name exactly
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
