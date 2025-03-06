using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxPlayerHealth;
    private int currentHealth;
    private bool isPlayerDead;

    private bool canTakeDamage = true;
    public int InvincibilitySeconds;

    public PlayerShield playerShield;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxPlayerHealth;
        playerShield = GetComponent<PlayerShield>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (canTakeDamage && !isPlayerDead && playerShield.GetShieldCount() < 1)
        {
            Debug.Log("No Shield, Took 1 Damage!");
            currentHealth -=1;

            if (currentHealth <= 0)
            {
                PlayerDeath();
            }
            else
            {
                StartCoroutine(InvincibilityFrames());
            }
        }
        else if (canTakeDamage && playerShield.GetShieldCount() >= 1)
        {
            Debug.Log("Removed 1 Shield!");
            playerShield.RemoveShield();
            StartCoroutine(InvincibilityFrames());
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Player Has Died!");
        isPlayerDead = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    IEnumerator InvincibilityFrames()
    {
        canTakeDamage = false;

        yield return new WaitForSeconds(InvincibilitySeconds);

        canTakeDamage = true;
    }

}
