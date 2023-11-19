using Car.Gear;
using Input;
using UnityEngine;

public class AutomaticGearManager : MonoBehaviour
{
    private AutomaticGearBox _gearBox;
    private GearShift _gearShift;

    private IInputManager _inputManager;

    // Start is called before the first frame update
    void Start()
    {
        _gearBox = GetComponent<AutomaticGearBox>();
        _inputManager = GetComponent<IInputManager>();
        _gearShift = GetComponentInChildren<GearShift>();
    }

    // Update is called once per frame
    void Update()
    {
        var shiftedGear = shiftGear();
        if (shiftedGear)
        {
            _gearShift.UpdateGearPosition(_gearBox.GetCurrentGear());
        }
    }

    private bool shiftGear()
    {
        if (_inputManager.GetGearUpInput())
        {
            _gearBox.UpShift();
            return true;
        }

        if (_inputManager.GetGearDownInput())
        {
            _gearBox.DownShift();
            return true;
        }

        if (_inputManager.GetGearDriveInput())
        {
            _gearBox.ShiftToDrive();
            return true;
        }
        
        if (_inputManager.GetGearReverseInput())
        {
            _gearBox.ShiftToReverse();
            return true;
        }
        
        if (_inputManager.GetGearParkInput())
        {
            _gearBox.ShiftToPark();
            return true;
        }
        
        if (_inputManager.GetGearNeutralInput())
        {
            _gearBox.ShiftToNeutral();
            return true;
        }

        return false;
    }
}