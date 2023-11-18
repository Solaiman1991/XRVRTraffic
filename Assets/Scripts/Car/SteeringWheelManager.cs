using UnityEngine;

namespace Car
{
    public class SteeringWheelManager : MonoBehaviour
    {
        // Steering wheel total angle: 550 = 360 + 180 + 10
        // Conversion ratio (520/38 = 13.684210526315789473684210526316) -- Steering wheel total degrees 520: Steering angle 38
        public const float ratio = 13.684210526315789473684210526316f;

        public Transform SteeringWheel;
        public float CurrentWheelAngle;
        
        private WheelBase _wheelBase;

        private void Start()
        {
            _wheelBase = GetComponent<WheelBase>();
        }

        private void FixedUpdate()
        {
            SteerWheel();
        }

        private void SteerWheel()
        {
            CurrentWheelAngle = _wheelBase.FRWheel.Collider.steerAngle;

            Vector3 locaRv3 = SteeringWheel.localRotation.eulerAngles;
            locaRv3.z = -CurrentWheelAngle * ratio;
            SteeringWheel.localRotation = Quaternion.Euler(locaRv3);
        }
    }
}