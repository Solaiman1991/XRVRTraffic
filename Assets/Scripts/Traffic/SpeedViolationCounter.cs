using TMPro;
using UnityEngine;
using Violation;

public class SpeedViolationCounter : MonoBehaviour
{
    private const float SpeedThreshold = 37f;
    public static int failureCount;
    public WheelBaseManager WheelBaseManager;
    [SerializeField] private ViolationManager _violationManager;
    private bool speedExceeded;

    private void Update()
    {
        if (WheelBaseManager != null)
        {
            if (WheelBaseManager.speed > SpeedThreshold && !speedExceeded)
            {
                speedExceeded = true;
                failureCount++;
                _violationManager.OnSpeedViolation();
            }
            else if (WheelBaseManager.speed <= SpeedThreshold && speedExceeded)
            {
                speedExceeded = false;
            }
        }
    }
    
}