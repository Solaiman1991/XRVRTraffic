using System;
using System.Collections;
using System.Collections.Generic;
using Car.Gear;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    [SerializeField] private GameObject car;

    public void ResetToInitial()
    {
        var gearBoxManger = car.GetComponentInChildren<AutomaticGearBox>();
        
        gearBoxManger.ShiftToPark();
        car.transform.rotation = gameObject.transform.rotation;
        car.transform.position = transform.position;
    }
    
}
