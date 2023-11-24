using Traffic;
using UnityEngine;
using Violation;

public class RedLightDetector : MonoBehaviour
{
    private ViolationManager _violationManager;

    private void Start()
    {
        _violationManager = FindFirstObjectByType<ViolationManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            var trafficLightController = GetComponentInParent<TrafficLightController>();
            if (trafficLightController != null &&
                trafficLightController.GetCurrentState() == TrafficLightController.LightState.Red)
            {
                var redLightController = FindObjectOfType<RedLightController>();
                if (redLightController != null)
                {
                    redLightController.IncrementViolationCount();
                    _violationManager.OnRedLightViolation();
                }
            }
        }
    }
}