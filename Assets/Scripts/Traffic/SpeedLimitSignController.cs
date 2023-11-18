using UnityEngine;
using System.Collections;

public class SpeedLimitSignController : MonoBehaviour
{
    public WheelBaseManager WheelBaseManager;
    public GameObject speedLimitSign; 
    private const float SpeedThreshold = 32f; 
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
        if (WheelBaseManager != null && speedLimitSign != null)
        {
            if (WheelBaseManager.speed > SpeedThreshold && blinkingCoroutine == null)
            {
                blinkingCoroutine = StartCoroutine(BlinkSpeedLimitSign());
            }
            else if (WheelBaseManager.speed <= SpeedThreshold && blinkingCoroutine != null)
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
