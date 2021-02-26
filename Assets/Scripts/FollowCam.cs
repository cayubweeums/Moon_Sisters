using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject player;

    public float boundaryPercent;
    public float easing = 0.1f;

    private Camera myCam;
    private float lBound, rBound, uBound, dBound;

    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();
        lBound = boundaryPercent * myCam.pixelWidth;
        rBound = myCam.pixelWidth - lBound;
        dBound = boundaryPercent * myCam.pixelHeight;
        uBound = myCam.pixelHeight - dBound;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myCam.orthographicSize = (Screen.height / 100f);

        if (player)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, easing) + new Vector3(0, 0, -10);
           /* Vector3 spriteLoc = myCam.WorldToScreenPoint(player.transform.position);
            Vector3 pos = transform.position;

            if (spriteLoc.x < lBound)
            {
                pos.x -= lBound - spriteLoc.x;
            } else if (spriteLoc.x > rBound)
            {
                pos.x += spriteLoc.x - rBound;
            }

            if (spriteLoc.y < dBound)
            {
                pos.y -= dBound - spriteLoc.y;
            }
            else if (spriteLoc.y > uBound)
            {
                pos.y += spriteLoc.y - uBound;
            }

            pos = Vector3.Lerp(transform.position, pos, easing);
            transform.position = pos;*/
        }
    }
    /*public void ChangeCam(GameObject player)
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, easing) + new Vector3(0, 0, -10f);
    }*/
}
