using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    // Zoom speeds, change values for faster or slower zoom
    private static readonly float PanSpeed = 5f;
    private static readonly float ZoomSpeedTouch = 0.05f;
    private static readonly float ZoomSpeedMouse = 10f;

    // change X, Y and ZoomBounds values depending on the size of the game scene 
    // First value represents the lower bound and seconds represents the upper bound
    private static readonly float[] BoundsX = new float[] { -9f, 9f };
    private static readonly float[] BoundsY = new float[] { -5f, 5f };
    private static readonly float[] BoundsZ = new float[] { -10f, 0.0f };
    private static readonly float[] ZoomBounds = new float[] { 15f, 60f };

    // Store a reference to our camera 
    private Camera cam;
    // Location of the users finger or mouse during the last frame 
    private Vector3 lastPanPosition;
    // Tracks ID of the finger being used to pan the camera 
    private int panFingerId;
    // Used to determine if the camera was being zoomed in the last frame
    private bool wasZoomingLastFrame;
    // Tracks location of the users fingers during last frame 
    private Vector2[] lastZoomPositions;
    //Disable/Enables camera movement
    private bool active;

    void Awake()
    {
        // Reference to the camera
        cam = GetComponent<Camera>();
        //Activate
        active = true;
    }
    void Update()
    {
        if (active)
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
    }
    void HandleTouch()
    {
        switch(Input.touchCount)
        {
            // Panning
            case 1:
                wasZoomingLastFrame = false;

                // If the touch began, capture its position and its finger ID 
                // if the finer ID of the touch doesnt match, skip 
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    lastPanPosition = touch.position;
                    panFingerId = touch.fingerId;          
                }
                else if(touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved)
                {
                    PanCamera(touch.position);
                }
                break;
            // Zooming 
            case 2:
                Vector2[] newPositions = new Vector2[] { Input.GetTouch(0).position, Input.GetTouch(1).position };
                if (!wasZoomingLastFrame)
                {
                    lastZoomPositions = newPositions;
                    wasZoomingLastFrame = true;
                }
                else
                {
                    // Zoom based on the distance between the new position compared to the distance between the previous position 
                    float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                    float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                    float offset = newDistance - oldDistance;

                    ZoomCamera(offset, ZoomSpeedTouch);
                }
                break;
            // If there are zero or more than two fingers on the screen, set the wasZoomingLastFrame to false
            default:
                wasZoomingLastFrame = false;
                break;
        }
    }
    void HandleMouse()
    {
        // Check if mouse was clicked and store mouse position as the lastPanPosition 
        // If mouse is still clicked 
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            PanCamera(Input.mousePosition);
        }
        // Zooming using the scroll wheel, distance that the scroll wheel has been scrolled since the last frame 
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll, ZoomSpeedMouse);
    }
    void PanCamera(Vector3 newPanPosition)
    {
        // Determines how much to move the camera. move multiplies the X & Z of the offset by the PanSpeed
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSpeed, 0, offset.y * PanSpeed);

        // Grab reference to camera and make sure it has stayed within the bounds 
        transform.Translate(move, Space.World);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.y = Mathf.Clamp(transform.position.y, BoundsY[0], BoundsY[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        // Chache the position 
        lastPanPosition = newPanPosition;
    }
    void ZoomCamera(float offset, float speed)
    {
        // Take a speed parameter because the mouse and touch controlled zooming are different 
        if (offset == 0)
        {
            return;
        }
        // Only need to modify the cameras field of view 
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
    }

    public void ActivateCameraMovement() {active = true; }
    public void DeactivateCameraMovement() { active = false; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NuclearStrikeButton"))
        {
            Debug.Log("Button Pressed");
        }
    }
}
