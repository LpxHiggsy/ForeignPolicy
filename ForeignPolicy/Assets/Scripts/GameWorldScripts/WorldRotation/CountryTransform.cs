using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryTransform : MonoBehaviour {


    private bool onScreen;
    public Vector3 origPos;
    public Vector3 leftPos;
    public Vector3 rightPos;

	// Use this for initialization
	void Start () {
        onScreen = true;
        origPos = transform.position;

        float screenWidth = 12.8f * 2.0f;
        leftPos = new Vector3(origPos.x - screenWidth, transform.position.y, transform.position.z);
        rightPos = new Vector3(origPos.x + screenWidth, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        if(onScreen)
        {
            //If Right
            if (transform.position.x > 12.8)
            {
                onScreen = false;
                transform.position = new Vector3(leftPos.x + transform.parent.transform.position.x,leftPos.y);
                Debug.Log("Right");
            }
            //if Left
            else if (transform.position.x < -12.8)
            {
                onScreen = false;
                transform.position = new Vector3(rightPos.x + transform.parent.transform.position.x, rightPos.y);
                Debug.Log("Left");
            }
        }

        if (transform.position.x < 12.8f && transform.position.x > -12.8f)
        {
            onScreen = true;
        }
    }
}
