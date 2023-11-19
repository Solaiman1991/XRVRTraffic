using Car.Wheel;
using UnityEngine;

//This is to stop the car from vibrating, values found from this forum: https://discussions.unity.com/t/unity-5-wheelcollider-jitter-vibration/138710/1

public class VibrationStopper : MonoBehaviour
{
    public int SpeedThroshould = 3;
    public int StepsBelowThreshold = 15;
    public int StepsAboveThreshold = 20;
    private WheelBase _wheelBase;
    // Start is called before the first frame update
    void Start()
    {
        _wheelBase = GetComponent<WheelBase>();
        _wheelBase.ApplyToAll(ConfigSubsteps);
    }
    void ConfigSubsteps(Wheel wheel)
    {
        wheel.Collider.ConfigureVehicleSubsteps(SpeedThroshould, StepsBelowThreshold, StepsAboveThreshold) ;
    }
}
