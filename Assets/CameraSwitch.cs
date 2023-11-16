using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject[] _camera; // Array of cameras
    public GameObject sideCams; // Side cameras
    private int i = 0;
    private bool pointView = false; // Used for cursor visibility and lock state

    private void Start()
    {
        _camera[0].SetActive(true); 
        sideCams.SetActive(true); 
    }

    private void FixedUpdate()
    {
        // Press the V key to switch the view
        if (Input.GetKeyDown(KeyCode.V))
        {
            _camera[i % _camera.Length].SetActive(false); // Disable current camera
            i++; // Move to the next camera
            _camera[i % _camera.Length].SetActive(true); // Enable the next camera

            // Check if the new active camera is the inside car camera (assuming it's the first in the array)
            if (i % _camera.Length == 1) 
            {
                // If inside car camera is active, disable side cameras
                sideCams.SetActive(false);
            }
            else 
            {
                // If not inside car camera, enable side cameras
                sideCams.SetActive(true);
            }
        }

        // Press the C key to hide or show the cursor
        if (Input.GetKeyDown(KeyCode.C))
        {
            pointView = !pointView; // Toggle pointView state
            Cursor.lockState = pointView ? CursorLockMode.Locked : CursorLockMode.Confined;
            Cursor.visible = pointView;
        }
    }
}
