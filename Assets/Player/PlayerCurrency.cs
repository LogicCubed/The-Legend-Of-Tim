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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CurrencyCount += 1;
            Destroy(collision.gameObject);
        }
    }

    public void AddCurrency(int amount)
    {
        CurrencyCount += amount;
    }

    public void RemoveCurrency(int amount)
    {
        CurrencyCount -= amount;
    }

    public int GetCurrencyCount()
    {
        return CurrencyCount;
    }
}
