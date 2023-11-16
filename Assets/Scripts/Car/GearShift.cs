using UnityEngine;
using UnityEngine.UI;

public class GearShift : MonoBehaviour
{
    public RectTransform gearImage; 
    public Vector2[] gearPositions; 
    private int currentGearIndex = 0; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentGearIndex--;
            if (currentGearIndex < 0)
            {
                currentGearIndex = 0; 
            }
            UpdateGearPosition();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentGearIndex++;
            if (currentGearIndex >= gearPositions.Length)
            {
                currentGearIndex = gearPositions.Length - 1; 
            }
            UpdateGearPosition();
        }
    }

    private void UpdateGearPosition()
    {
        gearImage.anchoredPosition = gearPositions[currentGearIndex]; 
    }

    private void Start()
    {
        gearPositions = new Vector2[4];
        gearPositions[0] = new Vector2(gearImage.anchoredPosition.x, 78); 
        gearPositions[1] = new Vector2(gearImage.anchoredPosition.x, 13); 
        gearPositions[2] = new Vector2(gearImage.anchoredPosition.x, -50); 
        gearPositions[3] = new Vector2(gearImage.anchoredPosition.x, -119); 

        UpdateGearPosition();
    }
}
