using System.Collections;
using UnityEngine;

public class HeartOMatic : MonoBehaviour
{
    public Animator anim;
    public PlayerHealth playerHealth;
    public GameObject health;

    public float shakeDuration = 0.25f;
    public float shakeAmount = 0.05f;
    private Vector3 originalPosition;

    private bool PlayerInRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UseMachine();
    }

    public void UseMachine()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && playerHealth.heartsStored >= 1 && playerHealth.currentHealth < playerHealth.maxPlayerHealth)
        {
            playerHealth.heartsStored -= 1;
            StartCoroutine(Shake());
            Vector3 spawnPosition = transform.position + new Vector3(0, -3, 0);
            Instantiate(health, spawnPosition, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            if (playerHealth.heartsStored >= 1 && playerHealth.currentHealth < playerHealth.maxPlayerHealth)
            {
                anim.SetBool("InRange", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            anim.SetBool("InRange", false);
        }
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {

            Vector3 randomShake = originalPosition + new Vector3(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), 0);
            transform.position = randomShake;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}
