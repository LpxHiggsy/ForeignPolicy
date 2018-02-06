using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour {


    public float rotationSpeed;
    
    private Vector3 _screenPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Cursor.visible = false;

        _screenPoint = Input.mousePosition;
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
    }

    void OnMouseDrag()
    {
        float changeInX = Input.mousePosition.x - _screenPoint.x;
        _screenPoint = Input.mousePosition;
        changeInX = changeInX * rotationSpeed;

        TransformWorld(new Vector3(changeInX, 0,0));
    }

    private void TransformWorld(Vector3 change)
    {
        transform.position += change;  
    }


}
