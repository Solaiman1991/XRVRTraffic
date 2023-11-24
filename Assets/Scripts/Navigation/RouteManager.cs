using Car;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    [SerializeField] private GameObject cityRouteObject;
    [SerializeField] private GameObject highwayRouteObject;
    [SerializeField] private GameObject FreeRoamRouteObject;

    [SerializeField] private DrivingInstructorAudioManager _audioManager;


    public void StartCityRoute()
    {
        cityRouteObject.SetActive(true);
        _audioManager.PlayStartCity();
    }

    public void StartHighway()
    {
        highwayRouteObject.SetActive(true);
        _audioManager.PlayStartHighway();
    }

    public void StartFreeRoam()
    {
        FreeRoamRouteObject.SetActive(true);
        _audioManager.PlayStartFreeRoam();
    }

    public void StopRoute()
    {
        _audioManager.PlayFinishLesson();
        cityRouteObject.SetActive(false);
        highwayRouteObject.SetActive(false);
        FreeRoamRouteObject.SetActive(false);
    }
}