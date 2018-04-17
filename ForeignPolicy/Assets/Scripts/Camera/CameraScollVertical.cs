using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScollVertical : MonoBehaviour {

    public float MaxY;
    public float MinY;

    private Vector3 _screenPoint;
    private bool _mouseButtonDown;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        
        //    _mouseButtonDown = Input.GetMouseButtonDown(0);
        
        //if(_mouseButtonDown)
        //{
        //    OnMouseDown();
            
        //    OnMouseDrag();
        //}
        //else
        //{
        //    OnMouseUp();
        //}
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
        float changeInY = Input.mousePosition.y - _screenPoint.y;

        Vector3 pos = Camera.main.transform.transform.position;
        Camera.main.transform.transform.position = new Vector3(pos.x, pos.y+=changeInY, pos.z);
    }
}
