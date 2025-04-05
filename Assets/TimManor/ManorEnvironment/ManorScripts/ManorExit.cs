using UnityEngine;

public class ManorExit : MonoBehaviour
{
    public SceneLoader sceneLoader;

    void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader.MainMenu();
    }
}
