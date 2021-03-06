using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLogic : MonoBehaviour
{

    public GameObject validPickup;
    private GameObject sister;
    private Rigidbody2D rb2d;

    private float horizontal;
    private bool pickupAllowed = false;
    private bool holdingSister = false;
    public float throwPowerx = 5;
    public float throwPowery = 5;
    private bool toggle = false;

    public float fix;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sister = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.E) && pickupAllowed){
            toggle = true;
            Debug.Log("Can Pick up");
        }

        if(Input.GetKeyDown(KeyCode.E) && holdingSister){
            toggle = false;
            Debug.Log("Can throw");
        }
        
        if(pickupAllowed && toggle){
            pickup();
        }

        if(holdingSister && !toggle){
            throwSister();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject == validPickup){
            pickupAllowed = true;
            Debug.Log("Allowed to pickup");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject == validPickup){
            pickupAllowed = false;
            Debug.Log("Not allowed to pickup anymore");
        }
    }

    private void throwSister(){
        validPickup.GetComponent< Rigidbody2D >().velocity = new Vector2(horizontal*throwPowerx, throwPowery);
        holdingSister = false;
    }

    private void pickup(){
        validPickup.transform.localPosition = new Vector2(sister.transform.position.x+fix,sister.transform.position.y+2.25f);
        holdingSister = true;
    }
}
