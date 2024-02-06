using Car;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class MenuManager : MonoBehaviour
{
    private ResetCar _resetCar;
    public CarAudioSourceManager CarAudioSource;
    public DrivingInstructorAudioManager Audio;
    public GameObject MainMenuStartButton;
    public GameObject ResultStartButton;

    public GameObject MainMenu;
    public DrivingReportMenuController ResultMenu;

    // Start is called before the first frame update
    private void Start()
    {
        _resetCar = GetComponentInParent<ResetCar>();
        InputManager.OnOptionsEvent += OnOptions;
        SpawnMainMenu();
    }

    private void OnDisable()
    {
        InputManager.OnOptionsEvent -= OnOptions;
    }

    private void OnOptions() {
        if (MainMenu.activeSelf)
        {
            DeSpwanMenu(MainMenu);
        }
        else {
            SpawnMainMenu();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SpawnMainMenu()
    {
        SpawnMenu(MainMenu);
        EventSystem.current.SetSelectedGameObject(MainMenuStartButton);
    }

    public void SpawnResultMenu()
    {
        CarAudioSource.StopEngine();
        SpawnMenu(ResultMenu.gameObject);
        EventSystem.current.SetSelectedGameObject(ResultStartButton);
    }

    public void CloseMainMenu()
    {
        CarAudioSource.StartEngine();
        DeSpwanMenu(MainMenu);
    }

    public void CloseResultMenu()
    {
        DeSpwanMenu(ResultMenu.gameObject);
        ResultMenu.Header.text = "Report";
    }

    private void SpawnMenu(GameObject menu)
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    private void DeSpwanMenu(GameObject menu)
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void SpawnGameOverMenu()
    {
        _resetCar.ResetToInitial();
        SpawnMenu(ResultMenu.gameObject);
        ResultMenu.SetGameOver();
        Audio.PlayGameOver();
        EventSystem.current.SetSelectedGameObject(ResultStartButton);
    }
}