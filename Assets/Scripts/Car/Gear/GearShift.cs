using UnityEngine;
using System.Collections.Generic;
using Car.Gear;

public class GearShift : MonoBehaviour
{
    public RectTransform gearImage;
    public Dictionary<Gear, Vector2> gearPositions;

    public void UpdateGearPosition(Gear newGear)
    {
        gearImage.anchoredPosition = gearPositions[newGear];
    }

    private void Start()
    {
        gearPositions = new Dictionary<Gear, Vector2>
        {
            { Gear.Park, new Vector2(gearImage.anchoredPosition.x, 78) },
            { Gear.Reverse, new Vector2(gearImage.anchoredPosition.x, 13) },
            { Gear.Neutral, new Vector2(gearImage.anchoredPosition.x, -50) },
            { Gear.Drive, new Vector2(gearImage.anchoredPosition.x, -119) }
        };

        UpdateGearPosition(Gear.Park);
    }
}
