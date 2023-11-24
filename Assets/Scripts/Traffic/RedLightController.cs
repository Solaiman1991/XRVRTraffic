using TMPro;
using UnityEngine;

// Include the TextMeshPro namespace

public class RedLightController : MonoBehaviour
{
    public int redLightViolations;
    public TextMeshProUGUI violationsText;

    private void Start()
    {
        UpdateViolationsText();
    }

    private void UpdateViolationsText()
    {
        if (violationsText != null) violationsText.text = " Red light violations: " + redLightViolations;
    }

    public void IncrementViolationCount()
    {
        redLightViolations++;
        UpdateViolationsText();
    }
}