using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScreenMenu;
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI totalDamageTaken;
    public TextMeshProUGUI totalCurrency;

    public CinemachineCamera cinemachineCamera;
    public CinematicBars cinematicBars;
    private float zoomAmount = 3f;

    public PlayerHealth playerHealth;
    public PlayerCurrency playerCurrency;
    public TextMeshProUGUI elapsedTime;

    public void ShowDeathScreen()
    {
        cinemachineCamera.Lens.OrthographicSize -= zoomAmount;
        cinematicBars.EnableBars();
    
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
