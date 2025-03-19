using UnityEngine;

public class BasicChestOpen : MonoBehaviour
{
    bool PlayerInRange = false;
    bool ChestIsOpened = false;

    public Animator anim;
    public GameObject EButton;
    private GameObject eButtonInstance;

    private KeyCollection playerKeys;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerKeys = GameObject.FindWithTag("Player").GetComponent<KeyCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleChest();
    }

    public void HandleChest()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpened && playerKeys.GetKeyCount() > 0)
        {
            OpenChest();
            playerKeys.KeysInInventory -= 1;
        }
        
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpened && playerKeys.GetKeyCount() < 1)
        {
            anim.ResetTrigger("NoKey"); 
            anim.SetTrigger("NoKey");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            if (playerKeys.GetKeyCount() > 0)
            {
                anim.SetBool("InRange", true);
                Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0);
                eButtonInstance = Instantiate(EButton, spawnPosition, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            Destroy(eButtonInstance);
            anim.SetBool("InRange", false);
        }
    }

    private void OpenChest()
    {
        ChestIsOpened = true;
        anim.SetTrigger("Open");
        Destroy(eButtonInstance);
    }

}
