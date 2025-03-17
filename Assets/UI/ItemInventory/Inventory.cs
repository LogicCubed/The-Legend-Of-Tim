using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject PlayerInventory;

    // Update is called once per frame
    void Update()
    {
        CheckQKey();
    }

    public void CheckQKey()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool isActive = PlayerInventory.activeSelf;
            PlayerInventory.SetActive(!isActive);
        }
    }
}
