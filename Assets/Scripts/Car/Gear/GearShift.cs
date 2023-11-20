using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Car.Gear
{
    public class GearShift : MonoBehaviour
    {
        private Image gearPickerImage;
        public Sprite gearDriveSprite;
        public Sprite gearNeutralSprite;
        public Sprite gearReverseSprite;
        public Sprite gearParkSprite;

        public void UpdateGearPosition(Gear newGear)
        {
            /*
            switch (newGear)
            {
                case Gear.Drive:
                    gearPickerImage.sprite = gearDriveSprite;
                    break;
                case Gear.Neutral:
                    gearPickerImage.sprite = gearNeutralSprite;
                    break;
                case Gear.Reverse:
                    gearPickerImage.sprite = gearReverseSprite;
                    break;
                case Gear.Park:
                    gearPickerImage.sprite = gearParkSprite;
                    break;
            }
            */
        }

        private void Start()
        {
            gearPickerImage = GetComponent<Image>();
            UpdateGearPosition(Gear.Park);
        }
    }
}
