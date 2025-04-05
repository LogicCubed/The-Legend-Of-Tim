using UnityEngine;

public class NonchalantPowerUp : MonoBehaviour
{

    bool PlayerInRange = false;


    private float startY;
    private Transform shadow;

    public PopUpManager popUpManager;
    private string pickupTitle = "Nonchalant";
    private string pickupText = "Chance to negate Damage!";
    public Sprite itemSprite;
    public Sprite itemGrade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if(PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            popUpManager.ShowPopUp(pickupTitle, pickupText, itemSprite, itemGrade);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
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
