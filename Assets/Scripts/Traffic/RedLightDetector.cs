using System;
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
            TrafficLightController trafficLightController = GetComponentInParent<TrafficLightController>();
            if (trafficLightController != null && trafficLightController.GetCurrentState() == TrafficLightController.LightState.Red)
            {
                RedLightController redLightController = FindObjectOfType<RedLightController>();
                if (redLightController != null)
                {
                    redLightController.IncrementViolationCount();
                    _violationManager.OnRedLightViolation();
                }
            }
        }
    }
}
