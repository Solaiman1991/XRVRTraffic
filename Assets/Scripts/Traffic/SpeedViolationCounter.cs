using UnityEngine;
using TMPro; 

public class SpeedViolationCounter : MonoBehaviour
{
    public WheelBaseManager WheelBaseManager;
    [SerializeField] private TextMeshProUGUI resultText; 
    private const float SpeedThreshold = 20f; 
    private bool speedExceeded = false;
    public int failureCount = 0; 

    void Update()
    {
        if (WheelBaseManager != null && resultText != null)
        {

            if (WheelBaseManager.speed > SpeedThreshold && !speedExceeded)
            {
                speedExceeded = true;
                failureCount++;
                UpdateResultText();
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
    