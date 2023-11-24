using TMPro;
using UnityEngine;
using Violation;

public class DrivingReportMenuController : MonoBehaviour
{
    public ViolationManager ViolationManager;
    public TextMeshProUGUI Header;
    public TextMeshProUGUI redLightViolationsResult;
    public TextMeshProUGUI speedViolationsResult;
    public TextMeshProUGUI rightOfWayViolationsResult;
    public TextMeshProUGUI fullStopViolationsResult;
    public TextMeshProUGUI indicatorViolationsResult;
    private MenuManager _menuManager;

    private void Start()
    {
        _menuManager = GetComponentInParent<MenuManager>();
    }

    public void OnEnable()
    {
        redLightViolationsResult.text = ViolationManager.GetNoOfRedLightViolations().ToString();
        speedViolationsResult.text = ViolationManager.GetNoOfSpeedViolations().ToString();
        rightOfWayViolationsResult.text = ViolationManager.GetNoOfRightOfWayViolations().ToString();
        fullStopViolationsResult.text = ViolationManager.GetNoOfFullStopViolations().ToString();
        indicatorViolationsResult.text = ViolationManager.GetNoOfIndicatorViolations().ToString();
    }

    public void OnDisable()
    {
        ViolationManager.Rest();
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