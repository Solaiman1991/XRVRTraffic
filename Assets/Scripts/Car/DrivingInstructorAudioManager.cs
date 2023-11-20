using UnityEngine;
using UnityEngine.Serialization;

namespace Car
{
    public class DrivingInstructorAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip startCityAudio;
        [SerializeField] private AudioClip turnLeftAudio1;
        [SerializeField] private AudioClip turnLeftAudio2;
        [SerializeField] private AudioClip turnLeftAudio3;
        [SerializeField] private AudioClip turnLeftAudio4;
        [SerializeField] private AudioClip turnRightAudio1;
        [SerializeField] private AudioClip turnRightAudio2;
        [SerializeField] private AudioClip turnRightAudio3;
        [SerializeField] private AudioClip turnRightAudio4;
        [SerializeField] private AudioClip finishLessonAudio;
        [SerializeField] private AudioClip parkAudio;
        [SerializeField] private AudioClip freeroamAudio;
        [SerializeField] private AudioClip redLightAudio1;
        [SerializeField] private AudioClip redLightAudio2;
        [SerializeField] private AudioClip speedLimitAudio;
        [SerializeField] private AudioClip indicatorAudio1;
        [SerializeField] private AudioClip indicatorAudio2;
        [SerializeField] private AudioClip slowDownAudio;
        [SerializeField] private AudioClip rightOfWayAudio;
        [SerializeField] private AudioClip fullStopAudio;
        

        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayStartCity()
        {
            audioSource.clip = startCityAudio;
            audioSource.Play();
        }

        public void PlayStartHighway()
        {
            
        }
        public void PlayStartFreeRoam()
        {
            audioSource.clip = freeroamAudio;
            audioSource.Play();
        }

        public void PlayTurnLeft()
        {
            audioSource.clip = turnLeftAudio1;
            audioSource.Play();
        }
    
        public void PlayTurnRight()
        {
            audioSource.clip = turnRightAudio1;
            audioSource.Play();
        }
        public void PlayFinishLesson()
        {
            audioSource.clip = finishLessonAudio;
            audioSource.Play();
        }
        public void PlayPark()
        {
            audioSource.clip = parkAudio;
            audioSource.Play();
        }

        public void PlayRedLightViolation()
        {
            audioSource.clip = redLightAudio1;
            audioSource.Play();
        }

        public void PlaySpeedViolation()
        {
            audioSource.clip = speedLimitAudio;
            audioSource.Play();
        }

        public void PlayIndicatorViolation()
        {
            audioSource.clip = indicatorAudio1;
            audioSource.Play();
        }

        public void PlayRightOfWayViolation()
        {
            audioSource.clip = rightOfWayAudio;
            audioSource.Play();
        }

        public void PlayFullStopViolation()
        {
            audioSource.clip = fullStopAudio;
            audioSource.Play();
        }
    }
}
