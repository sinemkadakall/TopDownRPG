using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterControl : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] public float moveSpeed;
    Vector2 movement;
    public Animator anim;

    bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

       
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        if (movement.y != 0 || movement.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(movement.x<0 && facingRight)
        {
            flip();
            facingRight = !facingRight;
        }
        else if(movement.x > 0 && !facingRight)
        {
            flip();
            facingRight = !facingRight;
        }
    }

    void flip()
    {
        transform.Rotate(0, 180f, 0);
    }
}
