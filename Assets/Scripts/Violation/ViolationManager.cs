using Car;
using UnityEngine;

namespace Violation
{
    public class ViolationManager : MonoBehaviour
    {
        [SerializeField] private DrivingInstructorAudioManager _audioManager;
        private int redLightViolations = 0;
        private int speedViolations = 0;
        private  int rightOfWayViolations = 0;
        private  int fullStopViolations = 0;
        private  int indicatorViolations = 0;
        
        public void OnRedLightViolation()
        {
            _audioManager.PlayRedLightViolation();
            redLightViolations++;
        }

        public void OnSpeedViolation()
        {
            _audioManager.PlaySpeedViolation();
            speedViolations++;
            Debug.Log("SPEED" + speedViolations);
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
    }
}
