using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 pos = this.transform.position;

        if(this.transform.position.x > 0 - this.GetComponent<RectTransform>().rect.width)
        {
            pos.x = pos.x - 5;
            this.transform.position = pos;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
