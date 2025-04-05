using UnityEngine;

public class ManorStatueButton : MonoBehaviour
{
    bool PlayerInRange = false;
    bool HasBeenPressed = false;

    public Animator anim;

    public BookshelfDoor bookshelfDoor;

    void Update()
    {
        HandleStatueButton();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            PlayerInRange = true;
            anim.SetBool("InRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            PlayerInRange = false;
            anim.SetBool("InRange", false);
        }
    }

    private void HandleStatueButton()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && HasBeenPressed == false)
        {
            bookshelfDoor.OpenDoors();
            HasBeenPressed = true;
            anim.SetTrigger("ButtonPressed");
        }
    }
}
