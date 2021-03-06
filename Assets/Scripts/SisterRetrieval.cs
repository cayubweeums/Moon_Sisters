using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterRetrieval : MonoBehaviour
{
    public GameObject sisterToRetrieve;
    private float xDiff,yDiff;
    private GameObject sisterWaiting;
    // Start is called before the first frame update
    void Start()
    {
        sisterWaiting = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            sisterToRetrieve.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            sisterToRetrieve.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            xDiff = (sisterWaiting.transform.position.x - sisterToRetrieve.transform.position.x)/1.5f;
            yDiff = (sisterWaiting.transform.position.y - sisterToRetrieve.transform.position.y)/1.5f;
            sisterToRetrieve.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDiff,yDiff);
        }else{
            sisterToRetrieve.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            sisterToRetrieve.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        
    }
}
