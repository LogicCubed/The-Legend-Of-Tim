using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScreenMenu;
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI totalDamageTaken;
    public TextMeshProUGUI totalCurrency;

    public PlayerHealth playerHealth;
    public PlayerCurrency playerCurrency;
    public Timer elapsedTime;

    public void ShowDeathScreen()
    {
        totalTime.text = "Total Time: ";

        totalDamageTaken.text = "Total Damage Taken: " + playerHealth.TotalDamageTaken.ToString();

        totalCurrency.text = "Money: " + playerCurrency.GetCurrencyCount();
        
        DeathScreenMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
