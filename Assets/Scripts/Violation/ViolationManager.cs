using Car;
using UnityEngine;

namespace Violation
{
    public class ViolationManager : MonoBehaviour
    {
        [SerializeField] private DrivingInstructorAudioManager _audioManager;
        private int fullStopViolations;
        private int indicatorViolations;
        private int redLightViolations;
        private int rightOfWayViolations;
        private int speedViolations;

        public void OnRedLightViolation()
        {
            _audioManager.PlayRedLightViolation();
            redLightViolations++;
        }

        public void OnSpeedViolation()
        {
            _audioManager.PlaySpeedViolation();
            speedViolations++;
        }

        public void OnRightOfWayViolation()
        {
            _audioManager.PlayRightOfWayViolation();
            rightOfWayViolations++;
        }

        public void OnFullStopViolation()
        {
            _audioManager.PlayFullStopViolation();
            fullStopViolations++;
        }

        public void OnIndicatorViolation()
        {
            _audioManager.PlayIndicatorViolation();
            indicatorViolations++;
        }

        public int GetNoOfRedLightViolations()
        {
            return redLightViolations;
        }

        public int GetNoOfSpeedViolations()
        {
            return speedViolations;
        }

        public int GetNoOfRightOfWayViolations()
        {
            return rightOfWayViolations;
        }

        public int GetNoOfFullStopViolations()
        {
            return fullStopViolations;
        }

        public int GetNoOfIndicatorViolations()
        {
            return indicatorViolations;
        }

        public void Rest()
        {
            redLightViolations = 0;
            speedViolations = 0;
            rightOfWayViolations = 0;
            fullStopViolations = 0;
            indicatorViolations = 0;
        }
    }
}