using UnityEngine;
using System.Collections;


public class DrivingController : MonoBehaviour
{
    public WheelCollider flWheelCollider;
    public WheelCollider frWheelCollider;
    public WheelCollider rlWheelCollider;
    public WheelCollider rrWheelCollider;

    public Transform flWheelModel; // Internal control of wheel rotation (child object)
    public Transform frWheelModel; // Internal control of wheel rotation (child object)
    public Transform rlWheelModel;
    public Transform rrWheelModel;

    public Transform flDiscBrake, frDiscBrake, centerOfMass; // Control steering externally (parent object), centerOfMass is the center of gravity

    public float motorTorque = 1600; // Maximum motor value
    public float steerAngle = 38; // Wheel steering angle
    public float brakeTorque = 2000; // Braking force

    public Transform SteeringWheel; // Steering wheel - Transform component
    public float CurrentWheelAngle = 0; // Current wheel rotation angle

    // Steering wheel total angle: 550 = 360 + 180 + 10
    // Conversion ratio (520/38 = 13.684210526315789473684210526316) -- Steering wheel total degrees 520: Steering angle 38
    public const float ratio = 13.684210526315789473684210526316f;
    [Header("This is the actual running speed of the car (KM/H)")]
    public float speed = 0;
    public float speedOrigin = 0;
    
    private void Start()
    {
        Rigidbody rigidboy = this.GetComponentInParent<Rigidbody>();
        rigidboy.centerOfMass = centerOfMass.localPosition;
    }

    private void Update()
    {
        // Spacebar - Brake
        if (Input.GetKey(KeyCode.Space))
        {
            rlWheelCollider.motorTorque = 0;
            rrWheelCollider.motorTorque = 0;
            Resistance();
        }
        else
        {
            CancelResistance();
        }
        
        // W|S Key - Start
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            CancelResistance();
        }
        
        // Power (wheel collider)
        rlWheelCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        rrWheelCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;

        // Steering (wheel collider)
        flWheelCollider.steerAngle = Input.GetAxis("Horizontal") * steerAngle;
        frWheelCollider.steerAngle = Input.GetAxis("Horizontal") * steerAngle;

        // Steering System
        SteerWheel();
        // Rotate Wheels
        RotateWheel();
    }
    
    private void RotateWheel()
    {
        // Front wheels (child objects)
        flDiscBrake.Rotate(flWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);
        frDiscBrake.Rotate(frWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);
        // Rear wheels
        rrWheelModel.Rotate(rrWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);
        rlWheelModel.Rotate(rlWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);

        // Car speed
        speed = flWheelCollider.rpm * (flWheelCollider.radius * 2 * Mathf.PI) * 60 / 1000;
        // Speed - remove decimal points
        speed = Mathf.Round(speed);
        speedOrigin = speed;
        // Absolute value
        speed = Mathf.Abs(speed);
    }

    /*
     * Steering
     */
    private void SteerWheel()
    {
        // Get the current wheel steering angle
        Vector3 localEulerAngles = flWheelModel.localEulerAngles;
        localEulerAngles.y = flWheelCollider.steerAngle;

        flWheelModel.localEulerAngles = localEulerAngles; // Control steering externally (flDiscBrake - parent object)
        frWheelModel.localEulerAngles = localEulerAngles;

        CurrentWheelAngle = flWheelCollider.steerAngle;

        // Synchronize steering wheel (OK, rotate around its own axis)
        Vector3 locaRv3 = SteeringWheel.localRotation.eulerAngles;
        locaRv3.z = -CurrentWheelAngle * ratio;
        SteeringWheel.localRotation = Quaternion.Euler(locaRv3);
    }


    public void Resistance()
    {
        // Apply brake torque to all wheels
        flWheelCollider.brakeTorque = brakeTorque;
        frWheelCollider.brakeTorque = brakeTorque;
        rlWheelCollider.brakeTorque = brakeTorque;
        rrWheelCollider.brakeTorque = brakeTorque;
    }


    public void CancelResistance()
    {
        // Remove brake torque from all wheels
        flWheelCollider.brakeTorque = 0;
        frWheelCollider.brakeTorque = 0;
        rlWheelCollider.brakeTorque = 0;
        rrWheelCollider.brakeTorque = 0;
    }
}
