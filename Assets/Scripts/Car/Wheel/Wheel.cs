using System;
using UnityEngine;

namespace Car.Wheel
{
    [Serializable]
    public class Wheel
    {
        public WheelCollider Collider;
        public Transform Transform;

        public void ApplyTorque(float power, float throttle)
        {
            Collider.motorTorque = power * throttle;
        }

        public void ApplySteer(float steeringAngle)
        {
            Collider.steerAngle = steeringAngle;
        }

        public void ApplyBreak(float power, float throttle)
        {
            Collider.brakeTorque = power * throttle;
        }
    }
}