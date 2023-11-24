using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private RouteManager _routeManager;

    private MenuManager _menuManager;

    // Start is called before the first frame update
    private void Start()
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