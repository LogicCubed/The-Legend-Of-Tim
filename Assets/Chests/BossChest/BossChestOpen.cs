using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class BossChestOpen : MonoBehaviour
{
    private bool PlayerInRange = false;
    bool ChestIsOpened = false;
    bool ChestIsOpening = false;

    public Animator anim;
    public GameObject EButton;
    private GameObject EButtonInstance;

    public CinemachineCamera cinemachineCamera;
    public CinematicBars cinematicBars;
    private float mashCounter = 0f;
    private float mashCounterStrength = 3f;
    private float decayRate = 3f;
    private float mashThreshold = 20f;
    public MashBar mashBar;
    private float zoomAmount = 3f;

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
        if (other.CompareTag("Player") && other.isTrigger)
        {
            PlayerInRange = true;
            if (playerKeys.GetKeyCount() > 0 && !ChestIsOpened)
            {
                anim.SetBool("InRange", true);
                Vector3 spawnPosition = transform.position + new Vector3(0, 2, 0);
                EButtonInstance = Instantiate(EButton, spawnPosition, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            PlayerInRange = false;
            Destroy(EButtonInstance);
            anim.SetBool("InRange", false);
        }
    }

    public void HandleChest()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpening && !ChestIsOpened && playerKeys.GetKeyCount() > 0)
        {
            ChestIsOpening = true;
            playerKeys.KeysInInventory -= 1;

            cinemachineCamera.Lens.OrthographicSize -= zoomAmount;
            playerMovement.DisableMovement();
            mashBar.gameObject.SetActive(true);
            cinematicBars.EnableBars();

            Destroy(EButtonInstance);
            Vector3 spawnPosition = transform.position + new Vector3(0, 2.5f, 0);
            EButtonInstance = Instantiate(EButton, spawnPosition, Quaternion.identity);
        }
        
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !ChestIsOpening && !ChestIsOpened && playerKeys.GetKeyCount() < 1)
        {
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

        cinemachineCamera.Lens.OrthographicSize += zoomAmount;
        playerMovement.EnableMovement();
        mashBar.gameObject.SetActive(false);
        cinematicBars.DisableBars();
        anim.SetTrigger("Open");
        Destroy(EButtonInstance);
    }

}
