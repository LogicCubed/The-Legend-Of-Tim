using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public GameObject heartPrefab;
    public Transform heartContainer;
    public PlayerHealth playerHealth;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.currentHealth;
        maxHealth = playerHealth.maxPlayerHealth;

        UpdateHealthDisplay();
    }

    void UpdateHealthDisplay()
    {
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            heart.transform.localPosition = new Vector3(i * 85, 0, 0);

            Image heartImage = heart.GetComponent<Image>();

            if (i < health)
            {
                heartImage.sprite = fullHeart;
            }
            else
            {
                heartImage.sprite = emptyHeart;
            }
        }
    }
}
