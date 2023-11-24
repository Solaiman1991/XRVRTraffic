using UnityEngine;

namespace Car
{
    public class SteeringWheelManager : MonoBehaviour
    {
        public float ratio = 10.825f;

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

            var locaRv3 = SteeringWheel.localRotation.eulerAngles;
            locaRv3.z = -CurrentWheelAngle * ratio;
            SteeringWheel.localRotation = Quaternion.Euler(locaRv3);
        }
    }
}