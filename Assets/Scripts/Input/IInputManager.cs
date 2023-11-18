namespace Input
{
    public interface IInputManager
    {
        float GetSteeringInput();
        float GetThrottleInput();
        float GetBrakeInput();
        bool GetGearUpInput();
        bool GetGearDownInput();
        bool GetStartEngineInput();
    }
}