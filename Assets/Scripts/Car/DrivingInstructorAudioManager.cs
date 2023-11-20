using UnityEngine;
using UnityEngine.Serialization;

namespace Car
{
    public class DrivingInstructorAudioManager : MonoBehaviour
    {
        [FormerlySerializedAs("startAudio")]
        [SerializeField] private AudioClip startCityAudio;
        [SerializeField] private AudioClip turnLeftAudio;
        [SerializeField] private AudioClip turnRightAudio;
        [SerializeField] private AudioClip finishLessonAudio;
        [SerializeField] private AudioClip parkAudio;

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
            
        }

        public void PlayTurnLeft()
        {
            audioSource.clip = turnLeftAudio;
            audioSource.Play();
        }
    
        public void PlayTurnRight()
        {
            audioSource.clip = turnRightAudio;
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
    }
}
