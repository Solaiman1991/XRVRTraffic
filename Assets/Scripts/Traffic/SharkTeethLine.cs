using UnityEngine;
using TMPro;
using Violation;

public class SharkTeethLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    public WheelBaseManager wheelBaseManager;
    public static int failureCount = 0; 
    public float speedLimit = 2f; 
    [SerializeField] private ViolationManager _violationManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && wheelBaseManager != null) 
        {
            float speed = wheelBaseManager.speed;
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
