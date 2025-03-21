using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class BossChestOpen : MonoBehaviour
{
    bool PlayerInRange = false;
    bool ChestIsOpened = false;
    bool ChestIsOpening = false;

    public Animator anim;
    public GameObject EButton;
    private GameObject eButtonInstance;

    public CinemachineCamera cinemachineCamera;
    public CinematicBars cinematicBars;
    private float mashCounter = 0f;
    private float mashCounterStrength = 3f;
    private float decayRate = 3f;
    private float mashThreshold = 20f;
    public MashBar mashBar;

    private KeyCollection playerKeys;
    public PlayerMovement playerMovement;

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
            if (playerKeys.GetKeyCount() > 0 && !ChestIsOpened)
            {
                anim.SetBool("InRange", true);
                Vector3 spawnPosition = transform.position + new Vector3(0, 2, 0);
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

    public void HandleChest()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpening && !ChestIsOpened && playerKeys.GetKeyCount() > 0)
        {
            ChestIsOpening = true;
            playerKeys.KeysInInventory -= 1;

            cinemachineCamera.Lens.OrthographicSize -= 4;
            playerMovement.DisableMovement();
            mashBar.gameObject.SetActive(true);
            cinematicBars.EnableBars();

            Destroy(eButtonInstance);
            Vector3 spawnPosition = transform.position + new Vector3(0, 3.5f, 0);
            eButtonInstance = Instantiate(EButton, spawnPosition, Quaternion.identity);
        }
        
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpening && !ChestIsOpened && playerKeys.GetKeyCount() < 1)
        {
            Debug.Log("NO KEY!");
            anim.ResetTrigger("NoKey"); 
            anim.SetTrigger("NoKey");
        }
    }

    private void OpeningChest()
    {
        if (ChestIsOpening)
        {
            mashBar.UpdateMashBar(mashCounter, mashThreshold);
            if (mashCounter > 0)
            {
                mashCounter -= decayRate * Time.deltaTime * 4f;
                mashCounter = Mathf.Max(mashCounter, 0f);
            }

            if (Input.GetKeyDown(KeyCode.E) && PlayerInRange)
            {
                mashCounter += mashCounterStrength;
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

        cinemachineCamera.Lens.OrthographicSize += 4;
        playerMovement.EnableMovement();
        mashBar.gameObject.SetActive(false);
        cinematicBars.DisableBars();
        Destroy(eButtonInstance);
        anim.SetTrigger("Open");
        Destroy(eButtonInstance);
    }

}
