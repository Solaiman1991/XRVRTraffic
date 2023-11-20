using System.Collections;
using Car.Gear;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    public AutomaticGearBox GearBox;
    public MenuManager MenuManager;
    private bool isInsideCollider = false;
    private float timeInsideCollider = 0f;
    public float requiredTime = 2f; 
    public float delayBeforeMenu = 2f;
    [SerializeField]
    RouteManager _routeManager;
    private bool _menuActive = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) 
        {
            isInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isInsideCollider = false;
            timeInsideCollider = 0f; 
            _menuActive = false;
        }
    }

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
            {
                if (GearBox.GetCurrentGear() == Gear.Park)
                {
                    _menuActive = true;
                    StartCoroutine(endLesson());
                }
            }
        }
    }

    private IEnumerator endLesson()
    {
        yield return new WaitForSeconds(delayBeforeMenu);

        MenuManager.SpawnResultMenu();
        _routeManager.StopRoute();        
    }
    
}
