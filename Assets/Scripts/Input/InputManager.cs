using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour, IInputManager
{

    private float SteeringValue;
    private float ThrottleValue;
    private float BrakeValue;
    public bool GearUp { get; private set; }
    public bool GearDown { get; private set; }
    public bool StartEngine { get; private set; }
    
    public bool LeftSign { get; private set; }
    public bool RightSign { get; private set; }
    public bool HavariSign { get; private set; }
    
    private ArrowBlinker arrowBlinker; 

    
    private void Start()
    {
        arrowBlinker = GetComponent<ArrowBlinker>(); 
    }
    
    void LateUpdate()
    {
        GearUp = false;
        GearDown = false;
        StartEngine = false;
    }

    void OnSteering(InputValue value)
    {
        SteeringValue = value.Get<float>();
    }

    void OnThrottle(InputValue value)
    {
        ThrottleValue = value.Get<float>();
    }

    void OnBrake(InputValue value)
    {
        BrakeValue = value.Get<float>();
    }

    void OnGearUp(InputValue value)
    {
        GearUp = true;
    }

    void OnGearDown(InputValue value)
    {
        GearDown = true;
    }

    void OnStartEngine(InputValue value)
    {
        StartEngine = true;
    }
    
    void OnLeftSign(InputValue value)
    {
        LeftSign = !LeftSign; 
        if (arrowBlinker != null)
        {
            arrowBlinker.ToggleLeftBlinking(); 
        }
    }
    
    void OnRightSign(InputValue value)
    {
        RightSign = !RightSign; 
        if (arrowBlinker != null)
        {
            arrowBlinker.ToggleRightBlinking(); 
        }
    }
    
    void OnHavariSign(InputValue value)
    {
        HavariSign = !HavariSign; 
        if (arrowBlinker != null)
        {
            arrowBlinker.ToggleHavariBlinking(); 
        }
    }
    
    
    
    

    // Reset gear and engine states at the end of each frame

    
    
    public float GetSteeringInput()
    {
        return SteeringValue;
    }

    public float GetThrottleInput()
    {
        return ThrottleValue;
    }

    public float GetBrakeInput()
    {
        return BrakeValue;
    }

    public bool GetGearUpInput()
    {
        return GearUp;
    }

    public bool GetGearDownInput()
    {
        return GearDown;
    }

    public bool GetLeftSignInput()
    {
        return LeftSign;
    }

    public bool GetRightSignInput()
    {
        return RightSign;
    }

    public bool GetHavariSignInput()
    {
        return HavariSign;
    }

    public bool GetStartEngineInput()
    {
        return StartEngine;
    }
}
