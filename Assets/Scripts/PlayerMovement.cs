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

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (horizontal != 0)
        {
            horizontal *= moveLimiter;
        }
        rb2d.velocity = new Vector2(horizontal * runSpeed, rb2d.velocity.y);
    }
}
