using System;
using UnityEngine;

namespace Car.Wheel
{
    [Serializable]
    public class WheelBase
    {
        public DriveType DriveType;
        public Wheel FRWheel;
        public Wheel FLWheel;
        public Wheel RRWheel;
        public Wheel RLWheel;

        public float motorTorque = 1600; 
        public float brakeTorque = 2000;
        public AnimationCurve steeringCurve;

        public int CurrentGearIndex;
        public Gear[] Gears = new[] { Gear.Park, Gear.Reverse, Gear.Neutral, Gear.Drive };
        public void ApplyToAll(Action<Wheel> action)
        {
            action(FRWheel);
            action(FLWheel);
            action(RRWheel);
            action(RLWheel);
        }

        public void ApplyToFrontWheels(Action<Wheel> action)
        {
            action(FRWheel);
            action(FLWheel);
        }

        public void ApplyToRearWheels(Action<Wheel> action)
        {
            action(RRWheel);
            action(RLWheel);
        }

        public void ApplyThrottle(float throttle)
        {
            var currentGear = Gears[CurrentGearIndex];
            switch (currentGear)
            {
                case Gear.Park:
                    return;
                case Gear.Neutral:
                    return;
                case Gear.Reverse:
                    throttle *= -1;
                    break;
                case Gear.Drive:
                    break;
            }
            
            Action<Wheel> torqueAction = wheel => wheel.ApplyTorque(motorTorque, throttle);

            switch (DriveType)
            {
                case DriveType.FrontWheelDrive:
                    ApplyToFrontWheels(torqueAction);
                    break;
                case DriveType.AllWheelDrive:
                    ApplyToAll(torqueAction);
                    break;
            }
        }

        public void ApplyBreak(float throttleInput)
        {
            Action<Wheel> torqueAction = wheel => wheel.ApplyBreak( brakeTorque, throttleInput);

            ApplyToAll(torqueAction);
        }

        public void ApplySteering(float steeringInput, float speed)
        {
            float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
            Action<Wheel> steeringAction = wheel => wheel.ApplySteer(steeringAngle);

            ApplyToFrontWheels(steeringAction);
        }

        public void UpShift()
        {
            CurrentGearIndex++;
            if (CurrentGearIndex > Gears.Length - 1)
            {
                CurrentGearIndex--;
            }
        }

        public void DownShift()
        {
            CurrentGearIndex--;
            if (CurrentGearIndex < 0)
            {
                CurrentGearIndex++;
            }
        }
  
    }
}

public enum Gear
{
    Park,
    Neutral,
    Drive,
    Reverse
}