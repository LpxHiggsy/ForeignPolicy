using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour {


    public float rotationSpeed;

    private float _offset;
    private Vector3 _origPos;
    private Vector3 _screenPoint;
    private float _screenWidth;
    List<Vector3> childPos;
    int childCount;

    // Use this for initialization
    void Start () {
        _screenWidth = 12.8f * 2.0f;
        _origPos = transform.position;
        _offset = GameObject.Find("Russia").GetComponent<PolygonCollider2D>().bounds.size.x;
        childCount = transform.childCount;

        childPos = new List<Vector3>();
        for (int i = 0; i < childCount; i++)
        {
            childPos.Add(transform.GetChild(i).transform.position);
        }
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

        if (transform.position.x > _screenWidth || transform.position.x < -_screenWidth)
        {
            transform.position = _origPos;

            for (int i = 0; i < childCount; i++)
            {
                transform.GetChild(i).transform.position = childPos[i];
            }
        }
    }


}
