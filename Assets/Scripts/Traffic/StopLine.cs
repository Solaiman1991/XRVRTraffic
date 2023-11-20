using UnityEngine;
using TMPro;

public class StopLine : MonoBehaviour
{
    public TextMeshProUGUI violationText;
    private float timeAtStopLine = 0f;
    private bool isCarAtStopLine = false;
    
    private static int violationCount = 0; 

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
            }
        }
    }

    private void Update()
    {
        if (isCarAtStopLine)
        {
            timeAtStopLine += Time.deltaTime;
        }
    }

    private void UpdateViolationText()
    {
        if (violationText != null)
        {
            violationText.text = "Stopline Violations: " + violationCount.ToString();
        }
    }
}
