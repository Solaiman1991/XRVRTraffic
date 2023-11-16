using System;
using UnityEngine;
using Car.Wheel;


public class DrivingController : MonoBehaviour
{
    public WheelBase Wheels;

    public Transform flDiscBrake, frDiscBrake;

    public Gear CurrentGear = Gear.Park;
    public Transform SteeringWheel;
    public float centerOfMassHeight = 0.5f;

    // Steering wheel total angle: 550 = 360 + 180 + 10
    // Conversion ratio (520/38 = 13.684210526315789473684210526316) -- Steering wheel total degrees 520: Steering angle 38
    public const float ratio = 13.684210526315789473684210526316f;

    [Header("This is the actual running speed of the car (KM/H)")]
    public float speed = 0;

    public float CurrentWheelAngle;

    private void Start()
    {
        Rigidbody rigidboy = this.GetComponentInParent<Rigidbody>();
        rigidboy.centerOfMass = new Vector3(0, -centerOfMassHeight, 0);
    }

    private void Update()
    {
        shiftGear();
    }

    private void FixedUpdate()
    {
        var throttleInput = Input.GetAxis("Vertical");
        var SteeringInput = Input.GetAxis("Horizontal");


        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
        {
            throttleInput = -1;
        }


        // Power (wheel collider)
        if (throttleInput > 0)
        {
            applyTorque(throttleInput);
        }
        else
        {
            applyBreak(throttleInput * -1);
        }

        applySteering(SteeringInput);

        // Steering System
        SteerWheel();
        // Rotate Wheels
        RotateWheel();
    }

    private void applySteering(float steeringInput)
    {
        Wheels.ApplySteering(steeringInput, speed);
    }

    private void applyBreak(float throttleInput)
    {
        Wheels.ApplyBreak(throttleInput);
    }

    private void applyTorque(float throttleInput)
    {
        Wheels.ApplyThrottle(throttleInput);
    }

    private void RotateWheel()
    {
        // Front wheels (child objects)
        flDiscBrake.Rotate(Wheels.FLWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);
        frDiscBrake.Rotate(Wheels.FRWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);
        // Rear wheels
        Wheels.RRWheel.Transform.Rotate(Wheels.RRWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);
        Wheels.RLWheel.Transform.Rotate(Wheels.RLWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);

        // Car speed
        speed = Wheels.FLWheel.Collider.rpm * (Wheels.FLWheel.Collider.radius * 2 * Mathf.PI) * 60 / 1000;

        // Speed - remove decimal points
        speed = Mathf.Round(speed);
    }


    private void SteerWheel()
    {
        CurrentWheelAngle = Wheels.FRWheel.Collider.steerAngle;

        Vector3 locaRv3 = SteeringWheel.localRotation.eulerAngles;
        locaRv3.z = -CurrentWheelAngle * ratio;
        SteeringWheel.localRotation = Quaternion.Euler(locaRv3);
    }

    private void shiftGear()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Wheels.DownShift();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Wheels.UpShift();
        }
    }
}