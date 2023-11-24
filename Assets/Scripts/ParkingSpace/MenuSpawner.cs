using System;
using System.Collections;
using Car.Gear;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    public AutomaticGearBox GearBox;
    public MenuManager MenuManager;
    public float requiredTime = 2f;
    public float delayBeforeMenu = 2f;

    [SerializeField] private RouteManager _routeManager;

    private bool _menuActive;
    private bool isInsideCollider;
    private float timeInsideCollider;

    private void FixedUpdate()
    {
        if (_menuActive)
        {
            timeInsideCollider = 0f;
            return;
        }

        if (isInsideCollider)
        {
            timeInsideCollider += Time.deltaTime;

            if (timeInsideCollider >= requiredTime)
                if (GearBox.GetCurrentGear() == Gear.Park)
                {
                    _menuActive = true;
                    StartCoroutine(endLesson());
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) isInsideCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            reset();
        }
    }

    private void OnDisable()
    {
        reset();
    }

    private void reset()
    {
        isInsideCollider = false;
        timeInsideCollider = 0f;
        _menuActive = false;
    }

    private IEnumerator endLesson()
    {
        yield return new WaitForSeconds(delayBeforeMenu);

        MenuManager.SpawnResultMenu();
        _routeManager.StopRoute();
    }
}