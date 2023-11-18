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
        _gearShift = GetComponent<GearShift>();
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

        return false;
    }
}