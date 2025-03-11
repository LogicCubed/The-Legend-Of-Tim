using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyDisplay : MonoBehaviour
{

    public Image KeyUI;
    public KeyCollection playerKeys;

    public TMP_Text keyText;

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
            keyText.enabled = false;
        }
        else
        {
            KeyUI.enabled = true;
            keyText.enabled = true;
            keyText.text = playerKeys.GetKeyCount().ToString();
        }
    }
}
