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

        private void ApplyThrottle(float throttle)
        {
            Action<Wheel> torqueAction = wheel => wheel.ApplyTorque(motorTorque, throttle);
            ApplyDriveTypeBehavior(torqueAction);
        }
        
        private void ApplyDriveTypeBehavior(Action<Wheel> action)
        {
            switch (DriveType)
            {
                case DriveType.FrontWheelDrive:
                    ApplyToFrontWheels(action);
                    break;
                case DriveType.AllWheelDrive:
                    ApplyToAll(action);
                    break;
            }
        }
        
        
        private void ApplyParkingBrake()
        {
            float parkingBrakeTorque = 10000; // Adjust this value as needed
            Action<Wheel> brakeAction = wheel => wheel.ApplyBreak(parkingBrakeTorque, 1f);
            ApplyToAll(brakeAction);
        }

        public void ApplyBreak(float throttleInput)
        {
            Action<Wheel> brakeAction = wheel => wheel.ApplyBreak(brakeTorque, throttleInput);
            ApplyToAll(brakeAction);
        }

        public void ApplySteering(float steeringInput, float speed)
        {
            float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
            Action<Wheel> steeringAction = wheel => wheel.ApplySteer(steeringAngle);
            ApplyToFrontWheels(steeringAction);
        }
        
        public void UpdateWheelBehavior(float throttle)
        {
            var currentGear = Gears[CurrentGearIndex];

            switch (currentGear)
            {
                case Gear.Park:
                    ApplyParkingBrake();
                    break;
                case Gear.Neutral:
                   
                    ApplyNeutralBehavior(throttle);
                    break;
                case Gear.Reverse:
                    ApplyThrottle(-throttle); 
                    break;
                case Gear.Drive:
                    ApplyThrottle(throttle);
                    break;
            }
        }
        
        private void ApplyNeutralBehavior(float throttle)
        {
            // Implement behavior for Neutral gear
         
        }
        public void UpShift()
        {
            if (CurrentGearIndex < Gears.Length - 1)
            {
                CurrentGearIndex++;
            }
        }

        public void DownShift()
        {
            if (CurrentGearIndex > 0)
            {
                CurrentGearIndex--;
            }
        }
    }
}

public enum Gear
{
    Park, Neutral, Drive, Reverse
}
