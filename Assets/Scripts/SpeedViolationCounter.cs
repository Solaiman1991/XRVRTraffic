using UnityEngine;
using TMPro; 

public class SpeedViolationCounter : MonoBehaviour
{
    public CarController carController;
    [SerializeField] private TextMeshProUGUI resultText; 
    private const float SpeedThreshold = 20f; 
    private bool speedExceeded = false;
    public int failureCount = 0; 

    void Update()
    {
        if (carController != null && resultText != null)
        {
            Debug.Log("Current Speed: " + carController.speed); 

            if (carController.speed > SpeedThreshold && !speedExceeded)
            {
                speedExceeded = true;
                failureCount++;
                UpdateResultText();
            }
            else if (carController.speed <= SpeedThreshold && speedExceeded)
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
