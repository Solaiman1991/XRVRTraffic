using TMPro;
using UnityEngine;
using Violation;

public class SharkTeethLine : MonoBehaviour
{
    public static int failureCount;
    [SerializeField] private TextMeshProUGUI resultText;
    public float speedLimit = 2f;
    private ViolationManager _violationManager;
    private WheelBaseManager _wheelBaseManager;

    private void Start()
    {
        _violationManager = FindFirstObjectByType<ViolationManager>();
        _wheelBaseManager = FindFirstObjectByType<WheelBaseManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && _wheelBaseManager != null)
        {
            var speed = _wheelBaseManager.speed;
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
        if (resultText != null) resultText.text = "U.Vigepligt Violations: " + failureCount;
    }
}