using System;
using System.Collections;
using Input;
using Unity.XR.CoreUtils;
using UnityEngine;

public class RecenterOrigin : MonoBehaviour
{
    public Transform Head;
    public Transform Origin;
    public Transform Target;
    
    public float delayBeforeRecenter = 2f;

    private IInputManager _inputManager;

    bool hasRecentered = false;
    void Start()
    {
        _inputManager = GetComponentInParent<IInputManager>();
    }
    
    void Update()
    {
        if (_inputManager.GetRecenterInput())
        {
            Recenter();
        }
        
    }
    
    void Recenter()
    {
        var rotationAngleY = Target.rotation.eulerAngles.y - Head.transform.rotation.eulerAngles.y ;
        Origin.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = Target.position - Head.transform.position;

        Origin.transform.position += distanceDiff;
    }

    IEnumerator StartRecenter()
    {
        yield return new WaitForSeconds(2f);
        
        Recenter();
    }
    
}
