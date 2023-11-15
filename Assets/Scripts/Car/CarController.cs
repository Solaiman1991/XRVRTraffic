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
    private Rigidbody CarRb;
    public float gripMultiplier = 2f;
    public float tractionControlMultiplier = 0.8f;

    public float SteeringMultiplier = 0.5f;
    public float centerOfMassHeight = 0.5f; // Adjust this value to set the center of mass height.

    // Start is called before the first frame update
    void Start()
    {
        CarRb = gameObject.GetComponent<Rigidbody>();
        
        CarRb.centerOfMass = new Vector3(0, -centerOfMassHeight, 0);

    }


    private void FixedUpdate()
    {
        speed = CarRb.velocity.magnitude;
        CheckInput();
        UpdateAllWheelsRotation();
        ApplyInput();
        TractionControl();
    }

    void TractionControl()
    {
    }

    void CheckInput()
    {
        ThrowtleInput = Input.GetAxis("Vertical");
        SteeringInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ThrowtleInput = -1;
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
        if (ThrowtleInput > 0)
        {
            Wheels.ApplyToFrontWheels(TorqueOnWheel);
        }
        else
        {
            Wheels.ApplyToAll(BreakTorque);
        }
        Wheels.ApplyToFrontWheels(ApplySteering);
    }

    void ApplySteering(Wheel wheel)
    {
        float steeringAngle = SteeringInput * steeringCurve.Evaluate(speed) * SteeringMultiplier;
        wheel.Collider.steerAngle = steeringAngle;
    }

    void TorqueOnWheel(Wheel wheel)
    {
        wheel.Collider.motorTorque = Power * ThrowtleInput;
    }

    void BreakTorque(Wheel wheel)
    {
        wheel.Collider.brakeTorque = BreakPower * (ThrowtleInput * -1);
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
