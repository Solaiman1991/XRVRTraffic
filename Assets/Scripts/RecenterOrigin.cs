using System;
using System.Collections;
using Input;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class RecenterOrigin : MonoBehaviour
{
    public Transform Head;

    public Transform Origin;

    public Transform Target;

    public float delayBeforeRecenter = 2f;

    private IInputManager _inputManager;

    bool missingFirstRecenter = true;

    void Start()
    {
        _inputManager = GetComponentInParent<IInputManager>();
    }

    void Update()
    {
        //This is something that only needs to be done when the game starts.
        //However it does not work to put it in the "Start" position, as the position of "Head" aka the main camera is not set yet.
        //So we simply check this until we have we have done it once, then we only do it again based on input.
        if (missingFirstRecenter && Head.transform.localPosition != new Vector3(0, 0, 0))
        {
            Recenter();
            missingFirstRecenter = false;
        }
        if (_inputManager.GetRecenterInput())
        {
            Recenter();
        }
    }

    void Recenter()
    {
        var rotationAngleY = Target.rotation.eulerAngles.y - Head.transform.rotation.eulerAngles.y;
        Origin.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = Target.position - Head.transform.position;

        Origin.transform.position += distanceDiff;
    }
}
