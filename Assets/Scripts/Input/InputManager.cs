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
    public bool GearDrive { get; private set; }
    public bool GearReverse { get; private set; }
    public bool GearPark { get; private set; }
    public bool GearNeutral { get; private set; }
    public bool StartEngine { get; private set; }
    
    public bool LeftSign { get; private set; }
    public bool RightSign { get; private set; }
    public bool HavariSign { get; private set; }
    public bool Recenter { get; private set;  }
    
    private ArrowBlinker arrowBlinker; 

    
    private void Start()
    {
        arrowBlinker = GetComponent<ArrowBlinker>(); 
    }
    
    void LateUpdate()
    {
        GearUp = false;
        GearDown = false;
        GearDrive = false;
        GearReverse = false;
        GearPark = false;
        GearNeutral = false;
        StartEngine = false;
        Recenter = false;
    }

    void OnSteering(InputValue value)
    {
        SteeringValue = value.Get<float>();
    }

    void OnThrottle(InputValue value)
    {
        ThrottleValue = Mathf.InverseLerp(-1f, 1f,value.Get<float>());
    }

    void OnBrake(InputValue value)
    {
        BrakeValue = Mathf.InverseLerp(-1f, 1f,value.Get<float>());
    }

    void OnGearUp(InputValue value)
    {
        GearUp = true;
    }

    void OnGearDown(InputValue value)
    {
        GearDown = true;
    }

    void OnGearDrive()
    {
        GearDrive = true;
    }

    void OnGearReverse()
    {
        GearReverse = true;
    }
    
    void OnGearPark()
    {
        GearPark = true;
    }

    void OnGearNeutral()
    {
        GearNeutral = true;
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

    void OnRecenter(InputValue value)
    {
        Recenter = true;
    }
    
    
    
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
    
    public bool GetGearDriveInput()
    {
        return GearDrive;
    }
    
    public bool GetGearReverseInput()
    {
        return GearReverse;
    }
    
    public bool GetGearParkInput()
    {
        return GearPark;
    }
    
    public bool GetGearNeutralInput()
    {
        return GearNeutral;
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

    public bool GetRecenterInput()
    {
        return Recenter;
    }
}
