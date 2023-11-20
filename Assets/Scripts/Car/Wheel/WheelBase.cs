using System;
using Car.Gear;
using Car.Wheel;
using UnityEngine;

public class WheelBase : MonoBehaviour
{
    public DriveType DriveType;
    public Wheel FRWheel;
    public Wheel FLWheel;
    public Wheel RRWheel;
    public Wheel RLWheel;

    public float motorTorque = 1600;
    public float brakeTorque = 2000;
    public AnimationCurve steeringCurve;

    private AutomaticGearBox _gearBox;

    private void Start()
    {
        _gearBox = GetComponent<AutomaticGearBox>();
        
    }
    
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
        var currentGear = _gearBox.GetCurrentGear();

        if (currentGear == Gear.Park)
        {
            ApplyParkingBrake();
            return;
        }

        switch (currentGear)
        {
            case Gear.Neutral:
                throttle = 0;
                break;
            case Gear.Reverse:
                throttle *= -1; 
                break;
            case Gear.Drive:
                break;
        }

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
        float parkingBrakeTorque = 10000; 
        Action<Wheel> brakeAction = wheel => wheel.ApplyBreak(parkingBrakeTorque, 1f);
        ApplyToAll(brakeAction);
    }

   
    public void ApplyBreak(float throttleInput)
    {
        Action<Wheel> torqueAction = wheel => wheel.ApplyBreak(brakeTorque, throttleInput);

        ApplyToAll(torqueAction);
    }

    public void ApplySteering(float steeringInput, float speed)
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        Action<Wheel> steeringAction = wheel => wheel.ApplySteer(steeringAngle);

        ApplyToFrontWheels(steeringAction);
    }
}