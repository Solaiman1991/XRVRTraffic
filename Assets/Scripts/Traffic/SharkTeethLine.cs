using System;
using UnityEngine;
using TMPro;
using Violation;

public class SharkTeethLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    private WheelBaseManager _wheelBaseManager;
    public static int failureCount = 0; 
    public float speedLimit = 2f; 
    private ViolationManager _violationManager;

    private void Start()
    {
        _violationManager = FindFirstObjectByType<ViolationManager>();
        _wheelBaseManager = FindFirstObjectByType<WheelBaseManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && _wheelBaseManager != null) 
        {
            float speed = _wheelBaseManager.speed;
            if (speed > speedLimit)
            {
                failureCount++;
                UpdateResultText();
                _violationManager.OnRightOfWayViolation();
            }
        }
    }

    private void UpdateResultText()
    {
        if (resultText != null)
        {
            resultText.text = "U.Vigepligt Violations: " + failureCount.ToString();
        }
    }
}
