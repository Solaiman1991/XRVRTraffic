using TMPro;
using UnityEngine;
using Violation;

public class DrivingReportMenuController : MonoBehaviour
{
    private MenuManager _menuManager;
    public ViolationManager ViolationManager;
    public TextMeshProUGUI Header;
    public TextMeshProUGUI redLightViolationsResult;
    public TextMeshProUGUI speedViolationsResult;
    public TextMeshProUGUI rightOfWayViolationsResult;
    public TextMeshProUGUI fullStopViolationsResult;
    public TextMeshProUGUI indicatorViolationsResult;

    void Start()
    {
        _menuManager = GetComponentInParent<MenuManager>();
        redLightViolationsResult.text = ViolationManager.GetNoOfRedLightViolations().ToString();
        speedViolationsResult.text = ViolationManager.GetNoOfSpeedViolations().ToString();
        rightOfWayViolationsResult.text = ViolationManager.GetNoOfRightOfWayViolations().ToString();
        fullStopViolationsResult.text = ViolationManager.GetNoOfFullStopViolations().ToString();
        indicatorViolationsResult.text = ViolationManager.GetNoOfIndicatorViolations().ToString();
    }

    public void OnTryAgain()
    {
        _menuManager.CloseResultMenu();
        _menuManager.SpawnMainMenu();
    }

    public void SetGameOver()
    {
        Header.text = "You Failed Numbnut";
    }
}