﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryTransform : MonoBehaviour {

    public float offset;

    private Vector3 leftPos;
    private Vector3 rightPos;
    private Vector3 posRelativeToParent;

	// Use this for initialization
	void Start () {

        offset = GameObject.Find("Russia").GetComponent<PolygonCollider2D>().bounds.size.x;
        float screenWidth = 12.8f * 2.0f;
        leftPos = new Vector3(transform.position.x - screenWidth, transform.position.y, transform.position.z);
        rightPos = new Vector3(transform.position.x + screenWidth, transform.position.y, transform.position.z);
        
        posRelativeToParent = -(transform.parent.transform.position - transform.position);
    }
	
	void Update () {
        
        if (transform.position.x > 12.8)
        { 
            if(transform.parent.transform.position.x < 0.0f)
            {
                transform.position = transform.parent.transform.position + posRelativeToParent;
            }
            else
            {
                transform.position = new Vector3(transform.parent.transform.position.x + leftPos.x, leftPos.y);
            }
        }
        else if (transform.position.x < -12.8)
        {
            if (transform.parent.transform.position.x > 0.0f)
            {
                transform.position = transform.parent.transform.position + posRelativeToParent;
            }
            else
            {
                transform.position = new Vector3(transform.parent.transform.position.x + rightPos.x, rightPos.y);
            }
        }
    }
}

