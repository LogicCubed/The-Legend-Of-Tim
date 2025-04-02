using System;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public bool PlayerInRange;
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
        StoreHealth();
        Bob();
    }

    void StoreHealth()
    {
        if (playerHealth != null && PlayerInRange && Input.GetKeyDown(KeyCode.E) && playerHealth.currentHealth == playerHealth.maxPlayerHealth)
        {
            playerHealth.heartsStored += 1;
            Destroy(gameObject);
            Debug.Log("PLAYER HAS " + playerHealth.heartsStored + " HEALTH STORED!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = true;
            if (playerHealth != null && playerHealth.currentHealth < playerHealth.maxPlayerHealth)
            {
                playerHealth.currentHealth += 1;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
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
