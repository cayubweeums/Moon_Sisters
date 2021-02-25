using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSisters : MonoBehaviour
{

    public GameObject sister1, sister2;

    private bool sister1Playing = true;
    
    // Start is called before the first frame update
    void Start()
    {
        sister2.gameObject.GetComponent< PlayerMovement >().enabled = false;
        sister2.gameObject.GetComponent< ThrowLogic >().enabled = false;
        sister2.gameObject.GetComponent< SisterRetrieval >().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switchSister();
        }
    }

    public void switchSister(){
        if(sister1Playing){
            sister1.gameObject.GetComponent< PlayerMovement >().enabled = false;
            sister2.gameObject.GetComponent< PlayerMovement >().enabled = true;
            sister1.gameObject.GetComponent< ThrowLogic >().enabled = false;
            sister2.gameObject.GetComponent< ThrowLogic >().enabled = true;
            sister1.gameObject.GetComponent< SisterRetrieval >().enabled = false;
            sister2.gameObject.GetComponent< SisterRetrieval >().enabled = true;
            sister1Playing = !sister1Playing;
        }else{
            sister1.gameObject.GetComponent< PlayerMovement >().enabled = true;
            sister2.gameObject.GetComponent< PlayerMovement >().enabled = false;
            sister1.gameObject.GetComponent< ThrowLogic >().enabled = true;
            sister2.gameObject.GetComponent< ThrowLogic >().enabled = false;
            sister1.gameObject.GetComponent< SisterRetrieval >().enabled = true;
            sister2.gameObject.GetComponent< SisterRetrieval >().enabled = false;
            sister1Playing = !sister1Playing;
        }
    }
    
}
