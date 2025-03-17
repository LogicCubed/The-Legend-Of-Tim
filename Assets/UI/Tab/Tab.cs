using UnityEngine;

public class Tab : MonoBehaviour
{

    public GameObject tab;

    // Update is called once per frame
    void Update()
    {
        CheckTabKey();
    }

    void CheckTabKey()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tab.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            tab.SetActive(false);
        }
    }
}
