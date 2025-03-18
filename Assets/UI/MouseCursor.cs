using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public RectTransform cursorTransform;
    private float rotationSpeed = 100f;

    void Start()
    {
        cursorTransform = GetComponent<RectTransform>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(Texture2D.whiteTexture, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
