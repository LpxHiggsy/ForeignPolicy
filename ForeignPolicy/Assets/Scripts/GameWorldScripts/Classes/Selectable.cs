
using UnityEngine;
using UnityEngine.Events;

using Assets.Scripts.GameWorldScripts.Classes;

[System.Serializable]
public class StringArgEvent : UnityEvent<string>
{
}
	
public class Selectable : MonoBehaviour
{
	private StringArgEvent MouseClickEvent;
	private StringArgEvent TouchPressEvent;

	private Color 				_originalColor 		{ get; set; }
	private PolygonCollider2D 	_colliderObject 	{ get; set; }
	private bool 				_initialSelection 	{ get; set; }
	    
    void Start()
    {
		_originalColor = GetComponent<SpriteRenderer> ().color;
		MouseClickEvent = new StringArgEvent ();
		TouchPressEvent = new StringArgEvent ();

        _colliderObject = GetComponent<PolygonCollider2D>();

		GameObject worldManagement = GameObject.FindGameObjectWithTag ("WorldManager");
		MouseClickEvent.AddListener (worldManagement.GetComponent<WorldManagement> ().clickCallBack);
		TouchPressEvent.AddListener (worldManagement.GetComponent<WorldManagement> ().clickCallBack);
	}

    void Update()
    {
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            HandleTouch();
        }
        else
        {
            HandleMouse();
        }
    }

    void HandleTouch()
    {
		CheckInitialTouch ();
		CheckConfirmationTouch ();
    }
    void HandleMouse()
	{
		CheckClick ();
	}

	void CheckInitialTouch()
	{
		switch (Input.touchCount) 
		{
			case 1:
			{
				Touch touch = Input.GetTouch (0);
				if (_colliderObject.OverlapPoint (touch.position)) 
				{
					_initialSelection = true;
				} 
				else 
				{
					_initialSelection = false;
				}
				break;
			}
			default:
			{
				_initialSelection = false;
				break;
			}
		}
	}
	void CheckConfirmationTouch()
	{
		if (_initialSelection) 
		{
			switch (Input.touchCount) 
			{
				case 1:
				{
					Touch touch = Input.GetTouch (0);
					if (_colliderObject.OverlapPoint (touch.position)) 
					{
						TouchPressEvent.Invoke (GetComponent<CountryStanding> ().Name);
						_initialSelection = false;
					} 
					else 
					{
						_initialSelection = false;
					}
					break;
				}
				default:
				{
					_initialSelection = false;
					break;
				}
			}
		}
	}
		
	void CheckClick()
	{
        //Being called in a update loop  ---> Can maybe be changed to event instead of constant check 
        bool mouseDown = Input.GetMouseButtonDown (0);
		if (mouseDown)
		{
			Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
			bool mouseCollided = _colliderObject.OverlapPoint(mousePosition);
			if (mouseCollided)
			{
				if (MouseClickEvent != null) 
				{
					MouseClickEvent.Invoke (GetComponent<CountryStanding>().Name);
				}
			}
		}
	}
}