using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    private float horizontal;
    private float vertical;
    //private float moveLimiter = 0.7f;
    public float jumpForce = 350;
    private bool jumping = false;
    private bool faceRight = true;
    public float jumpLimit = 2;
    private bool isLowGrav = false;
 
    public float _Velocity = 0.0f;      
    public float _MaxVelocity = 1.0f;   
    public float _Acc = 0.0f;           
    public float _AccSpeed = 0.1f;      
    public float _MaxAcc = 1.0f;      
    public float _MinAcc = -1.0f;
    public float _Deceleration = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space") && !jumping)
        {
            jumpLimit -= 1;
            rb2d.AddForce(new Vector2(0, jumpForce));
            if(jumpLimit == 0){
                jumping = true;
            }
        }
    }

    private void FixedUpdate()
    {
        /*
        if (horizontal != 0)
        {
            horizontal *= moveLimiter;
        }
        rb2d.velocity = new Vector2(horizontal * runSpeed, rb2d.velocity.y);
        */  
        if (horizontal < 0){
            _Acc = 0;
            _Acc -= _AccSpeed;
            acceleration();
        } 

        else if (horizontal > 0){
            _Acc = 0;
            _Acc += _AccSpeed;
            acceleration();
        }

        if(horizontal == 0){
            deceleration();
        }
 
        rb2d.velocity = new Vector2(_Velocity, rb2d.velocity.y);
    }

    private void acceleration(){
        if (_Acc > _MaxAcc)
            _Acc = _MaxAcc;

        else if (_Acc < _MinAcc)
            _Acc = _MinAcc;
 
        _Velocity += _Acc;
 
        if (_Velocity > _MaxVelocity)
            _Velocity = _MaxVelocity;
        else if (_Velocity < -_MaxVelocity)
            _Velocity = -_MaxVelocity;
    }

    private void deceleration(){
        if(_Velocity > 0){
            _Velocity -= _Deceleration;
        }else if(_Velocity < 0){
            _Velocity += _Deceleration;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

    private void flip(){
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void pickup(){
        
    }
}
