using UnityEngine;

public class PlayerLobby : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    private float x;
    private float y;

    public int moveSpeed = 12;

    private Vector2 lastDirection = Vector2.down;
    private Vector2 input;
    private bool moving;
    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Animate();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }

    private void GetInput()
    {

        if(canMove)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            input = new Vector2(x, y);
            input.Normalize();
        }
    }

    private void Animate()
    {
        moving = input.magnitude > 0.1f;

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
            lastDirection = input;
        }
        else
        {
            anim.SetFloat("X", lastDirection.x);
            anim.SetFloat("Y", lastDirection.y);
        }

        anim.SetBool("Moving", moving);
    }

    public void DisableMovement()
    {
        canMove = false;
        input = new Vector2(0, 0);
    }

    public void EnableMovement()
    {
        canMove = true;
    }
}
