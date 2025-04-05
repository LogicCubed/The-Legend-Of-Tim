using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartGame()
    {
        // Replace with Current Scene, or whatever the game scene is
        SceneManager.LoadScene(2);
    }

    public void Manor()
    {
        SceneManager.LoadScene("TimManor");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}