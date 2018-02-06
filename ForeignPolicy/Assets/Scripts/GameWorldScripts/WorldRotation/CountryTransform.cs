using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryTransform : MonoBehaviour {


    private bool onScreen;
	// Use this for initialization
	void Start () {
        onScreen = true;
	}
	
	// Update is called once per frame
	void Update () {

        float objectWidth = GetComponent<PolygonCollider2D>().bounds.size.x;

        if (onScreen)
        {
            if ((transform.position.x - (objectWidth/2))  > 12.8f || (transform.position.x + (objectWidth / 2)) < -12.8f)
            {
                onScreen = false;

                float biggestWidth = 10.0f;//GameObject.Find("Russia").GetComponent<PolygonCollider2D>().bounds.size.x;

                float difference = biggestWidth - objectWidth;

                Vector3 p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
                Vector3 p2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
                float unit = Vector3.Distance(p1, p2);

                float newXPos = transform.position.x;

                if (transform.position.x < 0)
                {
                    //Exit left side of screen
                    newXPos = (unit / 2) + difference;
                }
                else
                {
                    //Exit Right side of screen
                    newXPos = -(unit / 2) - difference;
                }

                Vector3 newPos = new Vector3(newXPos, transform.position.y, 0);

                Debug.Log(newPos.x);
                Debug.Log(onScreen);

                transform.position = newPos;

            }
        }

        if(transform.position.x < 12.8f && transform.position.x > -12.8f)
        {
            onScreen = true;
        }
        
	}
}
