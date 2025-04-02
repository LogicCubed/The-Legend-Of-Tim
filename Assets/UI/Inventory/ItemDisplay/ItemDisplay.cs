using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public PlayerCurrency playerCurrency;
    public TMP_Text coinText;

    public KeyCollection playerKeys;
    public TMP_Text keyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrency = GameObject.FindWithTag("Player").GetComponent<PlayerCurrency>();
        playerKeys = GameObject.FindWithTag("Player").GetComponent<KeyCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        coinText.text = playerCurrency.GetCurrencyCount().ToString();
        keyText.text = playerKeys.GetKeyCount().ToString();
    }
}
