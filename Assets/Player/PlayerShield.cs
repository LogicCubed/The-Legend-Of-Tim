using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public int currentShield;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddShield()
    {
        currentShield += 1;
    }

    public void RemoveShield()
    {
        currentShield -= 1;
    }

    public int GetShieldCount()
    {
        return currentShield;
    }
}
