using UnityEngine;

public class TNTItem : MonoBehaviour
{

    bool PlayerInRange = false;

    public Animator anim;
    private float startY;
    private Transform shadow;

    public PopUpManager popUpManager;
    private string pickupTitle = "TNT";
    private string pickupText = "BOOM";
    public Sprite itemSprite;
    public Sprite itemGrade;

    public ItemSlot itemSlot;
    public Item TNT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        popUpManager = FindFirstObjectByType<PopUpManager>();
        GameObject itemSlotObject = GameObject.Find("Canvas/ItemSlot");
        itemSlot = itemSlotObject.GetComponent<ItemSlot>();

        startY = transform.position.y;
        shadow = transform.Find("DropShadow");
    }

    // Update is called once per frame
    void Update()
    {
        ClaimPowerUp();
        Bob();
    }

    void ClaimPowerUp()
    {   
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            itemSlot.SetItem(TNT);
            popUpManager.ShowPopUp(pickupTitle, pickupText, itemSprite, itemGrade);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            anim.SetBool("InRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            anim.SetBool("InRange", false);
        }
    }

    public void Bob()
    {
        transform.position = new Vector3(
            transform.position.x,
            startY + Mathf.Sin(Time.time * 2f) * 0.25f,
            transform.position.z
        );

        shadow.position = new Vector3(shadow.position.x, startY - 0.75f, shadow.position.z);
    }
}
