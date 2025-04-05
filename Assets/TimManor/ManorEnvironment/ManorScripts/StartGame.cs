using UnityEngine;

public class StartGame : MonoBehaviour
{
    public SceneLoader sceneLoader;

    void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader.StartGame();
    }
}
