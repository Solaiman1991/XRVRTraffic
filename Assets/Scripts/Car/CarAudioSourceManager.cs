﻿using UnityEngine;
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
    [SerializeField] private AudioClip gameOver;
    bool isEngineRunning = false;

    private void Start()
    {
        _wheelBase = GetComponent<WheelBaseManager>();
        Audio_Runing = GetComponent<AudioSource>();
        _inputManager = GetComponent<IInputManager>();
    }


    public void StartEngine()
    {
        StartCoroutine(StartEngineRoutine());
    }

    public void StopEngine()
    {
        StartCoroutine(StopEngineRoutine());
    }

    public void PlayGameOver()
    {
        Audio_Runing.clip = gameOver;
        Audio_Runing.loop = false;
        Audio_Runing.pitch = 1f;
        Audio_Runing.Play();
    }

   
    
    

    IEnumerator StartEngineRoutine()
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

    IEnumerator StopEngineRoutine()
    {
        Audio_Runing.clip = stopClip;
        Audio_Runing.volume = 1f;
        Audio_Runing.pitch = 1f;
        Audio_Runing.loop = false;
        Audio_Runing.Play();

        yield return new WaitForSeconds(stopClip.length);

        isEngineRunning = false;
    }
    
}