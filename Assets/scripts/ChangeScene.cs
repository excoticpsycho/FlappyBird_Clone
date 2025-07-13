using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Call this method to change from "Home" to "Game"
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    // Call this method to quit the application
    public void QuitApplication()
    {
        Application.Quit();
        // This will only work in a built application, not in the Unity Editor
        Debug.Log("QuitApplication called.");
    }
}
