using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{

    public Image KeyUI;
    public KeyCollection playerKeys;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerKeys = GameObject.FindWithTag("Player").GetComponent<KeyCollection>();

        if (playerKeys.GetKeyCount() < 1)
        {
            KeyUI.enabled = false;
        }
        else
        {
            KeyUI.enabled = true;
        }
    }
}
