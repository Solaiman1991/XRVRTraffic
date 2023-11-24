using TMPro;
using UnityEngine;
using Violation;

public class StopLine : MonoBehaviour
{
    private static int violationCount;
    public TextMeshProUGUI violationText;
    private ViolationManager _violationManager;
    private bool isCarAtStopLine;
    private float timeAtStopLine;

    private void Start()
    {
        _violationManager = FindFirstObjectByType<ViolationManager>();
    }

    private void Update()
    {
        if (isCarAtStopLine) timeAtStopLine += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isCarAtStopLine = true;
            timeAtStopLine = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isCarAtStopLine = false;
            if (timeAtStopLine < 3f) // Less than 3 seconds
            {
                violationCount++;
                UpdateViolationText();
                _violationManager.OnFullStopViolation();
            }
        }
    }

    private void UpdateViolationText()
    {
        if (violationText != null) violationText.text = "Stopline Violations: " + violationCount;
    }
}