using Car;
using UnityEngine;

namespace Violation
{
    public class ViolationManager : MonoBehaviour
    {
        [SerializeField] private DrivingInstructorAudioManager _audioManager;
        
        public void OnRedLightViolation()
        {
            _audioManager.PlayRedLightViolation();   
        }

        public void OnSpeedViolation()
        {
            _audioManager.PlaySpeedViolation();
        }

        public void OnRightOfWayViolation()
        {
            _audioManager.PlayRightOfWayViolation();
        }

        public void OnFullStopViolation()
        {
            _audioManager.PlayFullStopViolation();
        }

        public void OnIndicatorViolation()
        {
            _audioManager.PlayIndicatorViolation();
        }
    }
}
