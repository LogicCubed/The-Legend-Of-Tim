using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public int CurrencyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCurrency(int amount)
    {
        CurrencyCount += amount;
        Debug.Log("You now have " + CurrencyCount + "Currency");
    }

    public void RemoveCurrency(int amount)
    {
        CurrencyCount -= amount;
        Debug.Log("You now have " + CurrencyCount + "Currency");
    }

    public int GetCurrencyCount()
    {
        return CurrencyCount;
    }
}
