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

    // Start is called before the first frame update
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
        }

        if(Input.GetKeyDown(KeyCode.E) && holdingSister){
            toggle = false;
        }
        
        if(pickupAllowed && toggle){
            pickup();
        }

        if(holdingSister && !toggle){
            throwSister();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == validPickup){
            pickupAllowed = true;
            Debug.Log("Allowed to pickup");
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject == validPickup){
            pickupAllowed = false;
            Debug.Log("Not allowed to pickup anymore");
        }
    }

    private void OnTriggerEnter(Collider collision){
        Debug.Log("collision");
    }

    private void OnTriggerExit(Collider collision){
        Debug.Log("collision");
    }

    private void throwSister(){
        validPickup.GetComponent< Rigidbody2D >().velocity = new Vector2(horizontal*throwPowerx, throwPowery);
        holdingSister = false;
    }

    private void pickup(){
        validPickup.transform.localPosition = new Vector2(sister.transform.position.x+2,sister.transform.position.y+2);
        holdingSister = true;
    }
}
