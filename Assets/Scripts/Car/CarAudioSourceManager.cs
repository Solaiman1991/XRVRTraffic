using UnityEngine;
using System.Collections;
using Input;

public class CarAudioSourceManager : MonoBehaviour
{
    private WheelBaseManager _wheelBase;
    private IInputManager _inputManager;

    [Header("Audio")] private AudioSource Audio_Runing;
    [SerializeField] private AudioClip startClip;
    [SerializeField] private AudioClip runClip;
    [SerializeField] private AudioClip stopClip;

    private void Start()
    {
        _wheelBase = GetComponent<WheelBaseManager>();
        Audio_Runing = GetComponent<AudioSource>();
        _inputManager = GetComponent<IInputManager>();
    }

    private void Update()
    {
        PlayAudio();
    }

    bool isEngineRunning = false;

    private void PlayAudio()
    {
        if (_inputManager.GetStartEngineInput())
        {
            if (!isEngineRunning)
            {
                StartCoroutine(StartEngine());
            }
        }
        /*
             if (Input.GetKeyDown(KeyCode.O)) // Engine off key
             {
                 if (isEngineRunning)
                 {
                     StartCoroutine(StopEngine());
                 }
             }
             */
    }

    IEnumerator StartEngine()
    {
        Audio_Runing.clip = startClip;
        Audio_Runing.volume = 0.3f;
        Audio_Runing.pitch = 1f;
        Audio_Runing.loop = false;
        Audio_Runing.Play();

        yield return new WaitForSeconds(startClip.length);

        isEngineRunning = true;
        StartCoroutine(RunEngine());
    }

    IEnumerator RunEngine()
    {
        Audio_Runing.clip = runClip;
        Audio_Runing.volume = 1f;
        Audio_Runing.loop = true;
        Audio_Runing.Play();

        while (Audio_Runing.isPlaying)
        {
            Audio_Runing.pitch = 0.4f + _wheelBase.speed / 200;
            yield return null;
        }
    }

    IEnumerator StopEngine()
    {
        Audio_Runing.clip = stopClip;
        Audio_Runing.volume = 1f;
        Audio_Runing.pitch = 1f;
        Audio_Runing.loop = false;
        Audio_Runing.Play();

        yield return new WaitForSeconds(stopClip.length);

        isEngineRunning = false;
    }

    public void StopAllAudio()
    {
        StopCoroutine(StartEngine());
        StopCoroutine(RunEngine());
        StopCoroutine(StopEngine());
        Audio_Runing.Stop();
    }
}