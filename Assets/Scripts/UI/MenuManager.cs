using System.Collections;
using Car;
using UnityEngine;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    public ResetCar resetCar;
    public CarAudioSourceManager CarAudioSource;
    public DrivingInstructorAudioManager Audio;
    public GameObject MainMenuStartButton;
    public GameObject ResultStartButton;

    public GameObject MainMenu;
    public DrivingReportMenuController ResultMenu;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMainMenu();
    }

    // Update is called once per frame
    void Update()
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
        resetCar.ResetToInitial();
        SpawnMenu(ResultMenu.gameObject);
        ResultMenu.SetGameOver();
        Audio.PlayGameOver();
        EventSystem.current.SetSelectedGameObject(ResultStartButton);
    }
}