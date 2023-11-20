using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingReportMenuController : MonoBehaviour
{

    private MenuManager _menuManager;
    void Start()
    {
        //TODO: Få results her ind
    }

    public void OnTryAgain()
    {
        _menuManager.CloseResultMenu();
        _menuManager.SpawnMainMenu();
    }
    
}
