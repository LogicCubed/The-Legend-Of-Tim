using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth.currentHealth < playerHealth.maxPlayerHealth)
            {
                playerHealth.currentHealth += 1;
                Destroy(gameObject);
            }
            else
            {
                // Logic to potentially store Health later
                Debug.Log("Health is Full!");
            }
        }
    }
}
