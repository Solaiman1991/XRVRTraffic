using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedLimitSignController : MonoBehaviour
{
    public CarController carController; 
    public GameObject speedLimitSign; 
    private const float SpeedThreshold = 20f; 
    private Coroutine blinkingCoroutine;

    void Start()
    {
        if (speedLimitSign != null)
        {
            speedLimitSign.SetActive(false);
        }
    }

    void Update()
    {
        if (carController != null && speedLimitSign != null)
        {
            if (carController.speed > SpeedThreshold && blinkingCoroutine == null)
            {
                blinkingCoroutine = StartCoroutine(BlinkSpeedLimitSign());
            }
            else if (carController.speed <= SpeedThreshold && blinkingCoroutine != null)
            {
                StopCoroutine(blinkingCoroutine);
                blinkingCoroutine = null;
                speedLimitSign.SetActive(false);
            }
        }
    }

    IEnumerator BlinkSpeedLimitSign()
    {
        while (true)
        {
            speedLimitSign.SetActive(!speedLimitSign.activeSelf);
            yield return new WaitForSeconds(0.7f); 
        }
    }
}
