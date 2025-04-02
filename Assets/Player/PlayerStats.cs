using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float PlayerDamage;
    public float PlayerAttackSpeed;
    public float PlayerSpeed;
    public float PlayerAccuracy;
    public float PlayerLuck;

    public int DamageToTake;

    public TMP_Text PlayerDamageText;
    public TMP_Text PlayerAttackSpeedText;
    public TMP_Text PlayerSpeedText;
    public TMP_Text PlayerAccuracyText;
    public TMP_Text PlayerLuckText;


    private void Start()
    {
        // Default Player Damage is 10
        PlayerDamage = 10f;

        // Default Player Attack Speed is ???
        PlayerAttackSpeed = 0.0f;

        // Default Player Speed is 15
        PlayerSpeed = 15f;

        // Default Player Accuracy is 50
        PlayerAccuracy = 50f;

        // Default Player Luck is 0
        PlayerLuck = 0.0f;

        DamageToTake = 1;
    }

    private void Update()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        float percentageDamage = PlayerDamage / 10f * 100f;
        PlayerDamageText.text = percentageDamage.ToString("F1") + "%";

        PlayerAttackSpeedText.text = PlayerAttackSpeed.ToString() + "%";

        float percentageSpeed = PlayerSpeed / 15.0f * 100f;
        PlayerSpeedText.text = percentageSpeed.ToString("F1") + "%";

        float percentageAccuracy = PlayerAccuracy / 50.0f * 100f;
        PlayerAccuracyText.text = PlayerAccuracy.ToString() + "%";

        PlayerLuckText.text = PlayerLuck.ToString() + "%";
    }
}