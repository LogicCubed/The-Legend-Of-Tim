using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public int shield;
    public Image[] shields;

    public PlayerShield playerShield;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shield = playerShield.currentShield;

        for (int i=0; i < shields.Length; i++)
        {
            if (i < playerShield.currentShield)
            {
                shields[i].enabled = true;
            }
            else
            {
                shields[i].enabled = false;
            }
        }    
    }
}
