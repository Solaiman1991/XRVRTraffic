using Car;
using UnityEngine;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    public CarAudioSourceManager CarAudioSource;

    public GameObject MainMenuStartButton;
    public GameObject ResultStartButton;
    public GameObject Background;

    public GameObject MainMenu;
    public GameObject ResultMenu;

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
        SpawnMenu(ResultMenu);
        EventSystem.current.SetSelectedGameObject(ResultStartButton);
    }

    public void CloseMainMenu()
    {
        CarAudioSource.StartEngine();
        DeSpwanMenu(MainMenu);
    }

    public void CloseResultMenu()
    {
        DeSpwanMenu(ResultMenu);
    }

    private void SpawnMenu(GameObject menu)
    {
        Time.timeScale = 0;
        Background.SetActive(true);
        menu.SetActive(true);
    }

    private void DeSpwanMenu(GameObject menu)
    {
        Time.timeScale = 1;
        Background.SetActive(false);
        menu.SetActive(false);
    }
}