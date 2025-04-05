using UnityEngine;

public class BookshelfDoor : MonoBehaviour
{
    public GameObject RightDoor;
    public GameObject LeftDoor;

    public CameraShake cameraShake;

    public void OpenDoors()
    {
        cameraShake.Shake(1.0f);
    }
}
