using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public int shield;

    public GameObject shieldPrefab;
    public Transform shieldContainer;
    public PlayerShield playerShield;

    public Sprite shieldSprite;

    public HealthDisplay healthDisplay;

    // Update is called once per frame
    void Update()
    {
        shield = playerShield.currentShield; 
        UpdateShieldDisplay();
        AdjustShieldContainerPosition();
    }
    
    void UpdateShieldDisplay()
    {
        foreach (Transform child in shieldContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < shield; i++)
        {
            GameObject shield = Instantiate(shieldPrefab, shieldContainer);
            shield.transform.localPosition = new Vector3(i * 52, 0, 0);

            Image shieldImage = shield.GetComponent<Image>();
            shieldImage.sprite = shieldSprite;
        }

    }

    void AdjustShieldContainerPosition()
    {
        int maxHealth = healthDisplay.maxHealth;

        float totalHeartsWidth = maxHealth;

        shieldContainer.localPosition = new Vector3(totalHeartsWidth - 269f, shieldContainer.localPosition.y, shieldContainer.localPosition.z);
    }
}