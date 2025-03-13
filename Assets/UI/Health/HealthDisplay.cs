using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public GameObject heartPrefab; // Prefab for heart image
    public Transform heartContainer; // Container where hearts will be placed
    public PlayerHealth playerHealth;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
    }

    void Update()
    {
        health = playerHealth.currentHealth;
        maxHealth = playerHealth.maxPlayerHealth;

        UpdateHealthDisplay();
    }

    void UpdateHealthDisplay()
    {
        // First, clear existing hearts
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }

        // Loop to display hearts based on maxHealth
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            heart.transform.localPosition = new Vector3(i * 52, 0, 0); // Adjust the positioning as needed

            Image heartImage = heart.GetComponent<Image>(); // Get the Image component of the heart

            if (i < health)
            {
                heartImage.sprite = fullHeart; // Full heart if health is greater than index
            }
            else
            {
                heartImage.sprite = emptyHeart; // Empty heart if health is less than index
            }
        }
    }
}
