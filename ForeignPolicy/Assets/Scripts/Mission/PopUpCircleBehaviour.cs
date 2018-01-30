using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PopUpCircleBehaviour : MonoBehaviour {

    // Use this for initialization
    public Canvas MissionSelectCanvas;

    private bool canvasIsOpen;
   
    void Start () {
        canvasIsOpen = false;
        MissionSelectCanvas.enabled = false;
    }

    public void OpenPopUpCirclePanel()
    {
        if(!canvasIsOpen)
        {
            MissionSelectCanvas.enabled = true;
            canvasIsOpen = true;
            //Camera.main.GetComponent<CameraHandler>().DeactivateCameraMovement(); //Camera script has changed
        }
        else if(canvasIsOpen)
        {
            MissionSelectCanvas.enabled = false;
            canvasIsOpen = false;
            //Camera.main.GetComponent<CameraHandler>().ActivateCameraMovement(); //Camera script has changed
        }
        
    }
}
