using Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IInputManager
{
    private ArrowBlinker arrowBlinker;
    private float BrakeValue;

    private float SteeringValue;
    private float ThrottleValue;
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
    public bool Recenter { get; private set; }


    private void Start()
    {
        arrowBlinker = GetComponent<ArrowBlinker>();
    }

    private void LateUpdate()
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

    private void OnSteering(InputValue value)
    {
        SteeringValue = value.Get<float>();
    }

    private void OnThrottle(InputValue value)
    {
        ThrottleValue = Mathf.InverseLerp(-1f, 1f, value.Get<float>());
        // ThrottleValue = value.Get<float>();
    }

    private void OnBrake(InputValue value)
    {
        BrakeValue = Mathf.InverseLerp(-1f, 1f, value.Get<float>());
        // BrakeValue = value.Get<float>();
    }

    private void OnGearUp(InputValue value)
    {
        GearUp = true;
    }

    private void OnGearDown(InputValue value)
    {
        GearDown = true;
    }

    private void OnGearDrive()
    {
        GearDrive = true;
    }

    private void OnGearReverse()
    {
        GearReverse = true;
    }

    private void OnGearPark()
    {
        GearPark = true;
    }

    private void OnGearNeutral()
    {
        GearNeutral = true;
    }

    private void OnStartEngine(InputValue value)
    {
        StartEngine = true;
    }

    private void OnLeftSign(InputValue value)
    {
        LeftSign = !LeftSign;
        if (arrowBlinker != null) arrowBlinker.ToggleLeftBlinking();
    }

    private void OnRightSign(InputValue value)
    {
        RightSign = !RightSign;
        if (arrowBlinker != null) arrowBlinker.ToggleRightBlinking();
    }

    private void OnHavariSign(InputValue value)
    {
        HavariSign = !HavariSign;
        if (arrowBlinker != null) arrowBlinker.ToggleHavariBlinking();
    }

    private void OnRecenter(InputValue value)
    {
        Recenter = true;
    }
}