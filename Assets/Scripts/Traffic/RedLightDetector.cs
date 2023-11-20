using Traffic;
using UnityEngine;

public class RedLightDetector : MonoBehaviour
{
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
                }
            }
        }
    }
}
