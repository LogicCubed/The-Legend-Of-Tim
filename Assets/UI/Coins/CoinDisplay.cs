using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Image KeyUI;
    public PlayerCurrency playerCurrency;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrency = GameObject.FindWithTag("Player").GetComponent<PlayerCurrency>();
    }
}
