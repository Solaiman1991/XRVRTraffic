using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Wheels Wheels;
    public float ThrowtleInput;
    private float SteeringInput;
    private float BreakInput;
    public float Power;
    public float BreakPower;
    private float slipAngle;
    public AnimationCurve steeringCurve;
    public float speed;
    public float MySpeed;
    private Rigidbody CarRb;

    // Start is called before the first frame update
    void Start()
    {
        CarRb = gameObject.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        speed = CarRb.velocity.magnitude;
        CheckInput();
        UpdateAllWheelsRotation();
        ApplyInput();
    }

    void CheckInput()
    {
        ThrowtleInput = Input.GetAxis("Vertical");
        SteeringInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            BreakInput = 1;
        }
        else
        {
            BreakInput = 0;
        }
    }

    void UpdateAllWheelsRotation()
    {
        Wheels.ApplyToAll(UpdateSingleWheelRotation);
    }

    void UpdateSingleWheelRotation(Wheel wheel)
    {
        Quaternion quat;
        Vector3 position;
        wheel.Collider.GetWorldPose(out position, out quat);
        wheel.Mesh.transform.rotation = quat;
    }

    void ApplyInput()
    {
        Wheels.ApplyToFrontWheels(TorqueOnWheel);
        Wheels.ApplyToFrontWheels(ApplySteering);
        Wheels.ApplyToFrontWheels(BreakTorque);
    }

    void ApplySteering(Wheel wheel)
    {
        float steeringAngle = SteeringInput * steeringCurve.Evaluate(speed);
        wheel.Collider.steerAngle = steeringAngle;
    }

    void TorqueOnWheel(Wheel wheel)
    {
        wheel.Collider.motorTorque = Power * ThrowtleInput * MySpeed;
    }

    void BreakTorque(Wheel wheel)
    {
        wheel.Collider.brakeTorque = BreakPower * BreakInput * MySpeed;
    }
}

[Serializable]
public class Wheels
{
    public Wheel FRWheel;
    public Wheel FLWheel;
    public Wheel RRWheel;
    public Wheel RLWheel;

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
}

[Serializable]
public class Wheel
{
    public WheelCollider Collider;
    public MeshRenderer Mesh;
}