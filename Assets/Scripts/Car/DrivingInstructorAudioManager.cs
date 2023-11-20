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
            var randomNumber = Random.Range(1, 5);
            switch (randomNumber)
            {
                case 1:
                    audioSource.clip = turnLeftAudio1;
                    break;
                case 2:
                    audioSource.clip = turnLeftAudio2;
                    break;
                case 3: 
                    audioSource.clip = turnLeftAudio3;
                    break;
                case 4:
                    audioSource.clip = turnLeftAudio4;
                    break;
            }
            audioSource.Play();
        }
    
        public void PlayTurnRight()
        {
            var randomNumber = Random.Range(1, 5);
            switch (randomNumber)
            {
                case 1:
                    audioSource.clip = turnRightAudio1;
                    break;
                case 2:
                    audioSource.clip = turnRightAudio2;
                    break;
                case 3: 
                    audioSource.clip = turnRightAudio3;
                    break;
                case 4:
                    audioSource.clip = turnRightAudio4;
                    break;
            }
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
            var randomNumber = Random.Range(1, 3);
            switch (randomNumber)
            {
                case 1:
                    audioSource.clip = redLightAudio1;
                    break;
                case 2:
                    audioSource.clip = redLightAudio2;
                    break;
            }
            audioSource.Play();
        }

        public void PlaySpeedViolation()
        {
            var randomNumber = Random.Range(1, 3);
            switch (randomNumber)
            {
                case 1:
                    audioSource.clip = speedLimitAudio;
                    break;
                case 2:
                    audioSource.clip = slowDownAudio;
                    break;
            }
            audioSource.Play();
        }

        public void PlayIndicatorViolation()
        {
            var randomNumber = Random.Range(1, 3);
            switch (randomNumber)
            {
                case 1:
                    audioSource.clip = indicatorAudio1;
                    break;
                case 2:
                    audioSource.clip = indicatorAudio2;
                    break;
            }
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
