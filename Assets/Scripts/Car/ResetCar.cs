using System;
using Car.Gear;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    private AutomaticGearBox _gearBox;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private void Start()
    {
        _gearBox = GetComponent<AutomaticGearBox>();
        _startRotation = transform.rotation;
        _startPosition = transform.position;
    }

    public void ResetToInitial()
    {
        // putting the car in park stops the cars momentum
        _gearBox.ShiftToPark();
        transform.rotation = _startRotation;
        transform.position = _startPosition;
    }
}