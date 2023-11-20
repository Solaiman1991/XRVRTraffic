using UnityEngine;
using TMPro;
using Violation;

public class SpeedViolationCounter : MonoBehaviour
{
    public WheelBaseManager WheelBaseManager;
    [SerializeField] private TextMeshProUGUI resultText; 
    private const float SpeedThreshold = 37f; 
    private bool speedExceeded = false;
    public static int failureCount = 0; 
    [SerializeField] private ViolationManager _violationManager;

    void Update()
    {
        if (WheelBaseManager != null && resultText != null)
        {

            if (WheelBaseManager.speed > SpeedThreshold && !speedExceeded)
            {
                speedExceeded = true;
                failureCount++;
                UpdateResultText();
                _violationManager.OnSpeedViolation();
            }
            else if (WheelBaseManager.speed <= SpeedThreshold && speedExceeded)
            {
                speedExceeded = false;
            }
        }
    }

    void UpdateResultText()
    {
        resultText.text = "Speed Violations: " + failureCount.ToString();
    }
}
    