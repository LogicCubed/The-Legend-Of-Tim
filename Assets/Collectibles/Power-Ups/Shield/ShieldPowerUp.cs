using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public PlayerShield playerShield;
    private float startY;
    private Transform shadow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = transform.position.y;
        shadow = transform.Find("DropShadow");
    }

    // Update is called once per frame
    void Update()
    {
        Bob();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerShield.AddShield();
            Destroy(gameObject);
        }
    }

    public void Bob()
    {
        transform.position = new Vector3(
            transform.position.x,
            startY + Mathf.Sin(Time.time * 2f) * 0.25f,
            transform.position.z
        );

        shadow.position = new Vector3(shadow.position.x, startY - 0.75f, shadow.position.z);
    }
}
