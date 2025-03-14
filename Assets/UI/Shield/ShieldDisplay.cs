using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public int shield;

    public GameObject shieldPrefab;
    public Transform shieldContainer;
    public PlayerShield playerShield;
    public PlayerHealth playerHealth;

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
            shield.transform.localPosition = new Vector3(i * 137, 0, 0);

            Image shieldImage = shield.GetComponent<Image>();
            shieldImage.sprite = shieldSprite;
        }

    }

    void AdjustShieldContainerPosition()
{
    // Calculate the total width of the heart containers in world units
    float heartsWidth = playerHealth.maxPlayerHealth * 137f; // Divide by PPU to convert to world units

    // Adjust the shield container's position to be after the hearts
    shieldContainer.localPosition = new Vector3(heartsWidth - 880f, shieldContainer.localPosition.y, shieldContainer.localPosition.z);
}

}