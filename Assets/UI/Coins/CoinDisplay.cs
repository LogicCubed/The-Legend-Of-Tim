using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public PlayerCurrency playerCurrency;
    public TMP_Text coinText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrency = GameObject.FindWithTag("Player").GetComponent<PlayerCurrency>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = playerCurrency.GetCurrencyCount().ToString();
    }
}
