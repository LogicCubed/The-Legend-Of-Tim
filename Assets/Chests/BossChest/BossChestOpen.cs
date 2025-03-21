using UnityEngine;

public class BossChestOpen : MonoBehaviour
{
    bool PlayerInRange = false;
    bool ChestIsOpened = false;
    bool ChestIsOpening = false;

    //public Animator anim;
    //public GameObject mashEButton;
    //private GameObject mashEButtonInstance;

    public CinematicBars cinematicBars;
    public GameObject UI;
    public float mashCounter = 0f;
    public float decayRate = 15f;
    public float mashThreshold = 15f;

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
        OpeningChest();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            Debug.Log("IN RANGE!");
            if (playerKeys.GetKeyCount() > 0 && !ChestIsOpened)
            {
                Debug.Log("HAS KEY AND IN RANGE!");
                //anim.SetBool("InRange", true);
                //Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0);
                //mashEButtonInstance = Instantiate(mashEButton, spawnPosition, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            Debug.Log("OUT OF RANGE!");
            //Destroy(eButtonInstance);
            //anim.SetBool("InRange", false);
        }
    }

    public void HandleChest()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpening && !ChestIsOpened && playerKeys.GetKeyCount() > 0)
        {
            ChestIsOpening = true;
            playerKeys.KeysInInventory -= 1;

            cinematicBars.EnableBars();
            UI.SetActive(false);
        }
        
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpening && !ChestIsOpened && playerKeys.GetKeyCount() < 1)
        {
            Debug.Log("NO KEY!");
            //anim.ResetTrigger("NoKey"); 
            //anim.SetTrigger("NoKey");
        }
    }

    private void OpeningChest()
    {
        if (ChestIsOpening)
        {
            if (mashCounter > 0)
            {
                mashCounter -= decayRate * Time.deltaTime;
                mashCounter = Mathf.Max(mashCounter, 0f);
            }

            if (Input.GetKeyDown(KeyCode.E) && PlayerInRange)
            {
                mashCounter += 1f;
                Debug.Log("Mash count: " + mashCounter);
            }

            if (mashCounter >= mashThreshold)
            {
                OpenChest();
            }
        }
    }

    private void OpenChest()
    {
        ChestIsOpened = true;
        ChestIsOpening = false;
        cinematicBars.DisableBars();
        UI.SetActive(true);
        Debug.Log("OPENED CHEST!");
        //anim.SetTrigger("Open");
        //Destroy(eButtonInstance);
    }

}
