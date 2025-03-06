using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    public int KeysInInventory;

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
        if (collision.gameObject.CompareTag("Key"))
        {
            KeysInInventory += 1;
            Destroy(collision.gameObject);
        }
    }

    public int GetKeyCount()
    {
        return KeysInInventory;
    }

}
