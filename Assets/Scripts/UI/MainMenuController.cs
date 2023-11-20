using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private MenuManager _menuManager;

    [SerializeField]
    RouteManager _routeManager;
    // Start is called before the first frame update
    void Start()
    {
        _menuManager = GetComponentInParent<MenuManager>();
    }

    public void OnCityDrive()
    {
        _menuManager.CloseMainMenu();
        _routeManager.StartCityRoute();
    }

    public void OnHighwayDrive()
    {
        _menuManager.CloseMainMenu();
        _routeManager.StartHighway();
    }

    public void OnFreeRoam()
    {
        _menuManager.CloseMainMenu();
        _routeManager.StartFreeRoam();
    }
}