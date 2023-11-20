using UnityEngine;
using TMPro;
using Traffic;
using Violation; // Include the TextMeshPro namespace

public class RedLightController : MonoBehaviour
{
    public int redLightViolations = 0;
    public TextMeshProUGUI violationsText;
    [SerializeField] private ViolationManager _violationManager;

    private void Start()
    {
        UpdateViolationsText();
    }

    private void OnTriggerEnter(Collider other)
    {
        TrafficLightController trafficLight = other.GetComponentInParent<TrafficLightController>();

        if (trafficLight != null && trafficLight.GetCurrentState() == TrafficLightController.LightState.Red)
        {
            redLightViolations++; 
            UpdateViolationsText();
            _violationManager.OnRedLightViolation();
        }
    }

    private void UpdateViolationsText()
    {
        if (violationsText != null)
        {
            violationsText.text = " Red light violations: " + redLightViolations.ToString();
        }
    }
    
    public void IncrementViolationCount()
    {
        redLightViolations++;
        UpdateViolationsText();
    }
}
