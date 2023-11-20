using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private MenuManager _menuManager;

    // Start is called before the first frame update
    void Start()
    {
        _menuManager = GetComponentInParent<MenuManager>();
    }

    public void OnCityDrive()
    {
        _menuManager.CloseMainMenu();

        //TODO: Lave ting der skal til får at den gamemode er på
    }

    public void OnHightwayDrive()
    {
        _menuManager.CloseMainMenu();

        //TODO: Lave ting der skal til får at den gamemode er på
    }

    public void OnFreeRoam()
    {
        _menuManager.CloseMainMenu();

        //TODO: Lave ting der skal til får at den gamemode er på
    }
}