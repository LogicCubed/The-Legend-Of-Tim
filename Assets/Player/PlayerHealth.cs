using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxPlayerHealth;
    public int currentHealth;
    private bool isPlayerDead;

    private bool canTakeDamage = true;
    public int InvincibilitySeconds;

    public PlayerShield playerShield;

    public CameraShake cameraShake;

    public DeathScreen deathScreen;

    public int TotalDamageTaken;
    
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

    public void AddHealth()
    {
        currentHealth += 1;
        maxPlayerHealth += 1;
    }

    public void TakeDamage()
    {
        if (canTakeDamage && !isPlayerDead && playerShield.GetShieldCount() < 1)
        {
            cameraShake.Shake(0.5f);
            TotalDamageTaken += 1;
            currentHealth -= 1;

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
            cameraShake.Shake(0.5f);
            TotalDamageTaken += 1;
            playerShield.RemoveShield();
            StartCoroutine(InvincibilityFrames());
        }
    }

    private void PlayerDeath()
    {
        deathScreen.ShowDeathScreen();
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
