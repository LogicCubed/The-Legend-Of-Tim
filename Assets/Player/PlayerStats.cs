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
    public float KnockbackDealt;

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

        // Default Player Speed is 12
        PlayerSpeed = 12f;

        // Default Player Accuracy is 50
        PlayerAccuracy = 50f;

        // Default Player Luck is 25
        PlayerLuck = 100f;

        // Default Player Damage Taken is 1
        DamageToTake = 1;

        //Default Player Knockback Dealt is 3 (SUBJECT TO CHANGE)
        KnockbackDealt = 2f;
    }

    private void Update()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        float percentageDamage = PlayerDamage / 10.0f * 100f;
        PlayerDamageText.text = percentageDamage.ToString("F1") + "%";

        PlayerAttackSpeedText.text = PlayerAttackSpeed.ToString() + "%";

        float percentageSpeed = PlayerSpeed / 12.0f * 100f;
        PlayerSpeedText.text = percentageSpeed.ToString("F1") + "%";

        float percentageAccuracy = PlayerAccuracy / 50.0f * 100f;
        PlayerAccuracyText.text = PlayerAccuracy.ToString() + "%";

        float percentageLuck = PlayerLuck / 100.0f * 100f;
        PlayerLuckText.text = PlayerLuck.ToString() + "%";
    }
}