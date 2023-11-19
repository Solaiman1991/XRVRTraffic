namespace Input
{
    public interface IInputManager
    {
        float GetSteeringInput();
        float GetThrottleInput();
        float GetBrakeInput();
        bool GetGearUpInput();
        bool GetGearDownInput();
        bool GetGearDriveInput();
        bool GetGearReverseInput();
        bool GetGearParkInput();
        bool GetGearNeutralInput();
        
        bool GetLeftSignInput();
        bool GetRightSignInput();
        bool GetHavariSignInput();
      
        bool GetStartEngineInput();
    }
}