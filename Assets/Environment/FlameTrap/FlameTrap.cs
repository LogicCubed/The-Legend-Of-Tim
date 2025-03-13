using System.Collections;
using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    private bool FlameTrapInUse;

    public GameObject flame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && FlameTrapInUse == false)
        {
            FlameTrapInUse = true;
            StartCoroutine(Flame());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        FlameTrapInUse = false;
    }

    IEnumerator Flame()
    {
        yield return new WaitForSeconds(0.4f);

        Instantiate(flame, transform.position + new Vector3(0, 2f, -1f), Quaternion.identity);
    }
}
