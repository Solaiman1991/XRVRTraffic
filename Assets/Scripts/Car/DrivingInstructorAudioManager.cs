using UnityEngine;

namespace Car
{
    public class DrivingInstructorAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip startAudio;
        [SerializeField] private AudioClip turnLeftAudio;
        [SerializeField] private AudioClip turnRightAudio;

        private AudioSource audioSource;

        void Start()
        {
            
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = startAudio;
            audioSource.Play();
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
    }
}
