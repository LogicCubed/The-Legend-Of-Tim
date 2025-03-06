using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    public float moveSpeed;

    public Rigidbody2D rb;

    private float x;
    private float y;

    private Vector2 lastDirection = Vector2.down;
    private Vector2 input;
    private bool moving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
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

}
