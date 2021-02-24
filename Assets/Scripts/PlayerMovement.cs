using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;
    public float runSpeed = 0.1f;
    public float jumpForce = 350;
    private bool jumping = false;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("space") && !jumping)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            jumping = true;
        }

    }

    private void FixedUpdate()
    {
        if (horizontal != 0)
        {
            horizontal *= moveLimiter;
        }
        rb2d.velocity = new Vector2(horizontal * runSpeed, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
}
