using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Sprite SpikeTrapUnarmed;
    public Sprite SpikeTrapArming;
    public Sprite SpikeTrapArmed;

    private bool SpikeTrapInUse;
    private bool InSpikeHitbox;
    private bool SpikesOut;

    private SpriteRenderer spriteRenderer;
    private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InSpikeHitbox && SpikesOut)
        {
            playerHealth.TakeDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && SpikeTrapInUse == false)
        {
            SpikeTrapInUse = true;
            spriteRenderer.sprite = SpikeTrapArming;
            StartCoroutine(Spikes());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        InSpikeHitbox = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        InSpikeHitbox = true;
    }

    IEnumerator Spikes()
    {
        yield return new WaitForSeconds(0.5f);

        SpikesOut = true;
        spriteRenderer.sprite = SpikeTrapArmed;
        StartCoroutine(UnArmSpikes());
    }

    IEnumerator UnArmSpikes()
    {
        yield return new WaitForSeconds(2f);

        SpikeTrapInUse = false;
        SpikesOut = false;
        spriteRenderer.sprite = SpikeTrapUnarmed;
    }

}
