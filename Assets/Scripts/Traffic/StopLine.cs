using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StopLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    public int failureCount = 0; 
    public float speedLimit = 15f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) 
        {
            float speed = GetCarSpeed(other);
            if (speed > speedLimit)
            {
                failureCount++;
                resultText.text = "Traffic Violations: " + failureCount;
                Debug.Log("Stop line crossed at high speed. Fail count: " + failureCount);
            }
            else
            {
                Debug.Log("Stop line crossed at safe speed.");
            }
            Debug.Log("Triggered with: " + other.gameObject.name);
        }
    }

    private float GetCarSpeed(Collider car)
    {
        Rigidbody carRb = car.GetComponent<Rigidbody>();
        if (carRb != null)
        {
            // Convert speed from m/s to km/h
            return carRb.velocity.magnitude * 3.6f;
        }

        return 0f; 
    }

    public void ResetFailures()
    {
        failureCount = 0;
        resultText.text = "Traffic Violations: " + failureCount;
    }
}
