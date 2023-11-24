using System.Collections;
using UnityEngine;

public class SpeedLimitManager : MonoBehaviour
{
    public WheelBaseManager WheelBaseManager;
    private Coroutine blinkingCoroutine;


    private float currenctSpeedLimit;
    private GameObject currentSign;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (WheelBaseManager.speed > currenctSpeedLimit && blinkingCoroutine == null)
        {
            blinkingCoroutine = StartCoroutine(BlinkSpeedLimitSign());
        }
        else if (WheelBaseManager.speed <= currenctSpeedLimit && blinkingCoroutine != null)
        {
            StopCoroutine(blinkingCoroutine);
            blinkingCoroutine = null;
            DeactivateAllSigns();
        }
    }


    public void SetSpeedLimit(float newSpeedLimit, GameObject newCurrentSign)
    {
        DeactivateAllSigns();
        currenctSpeedLimit = newSpeedLimit;
        currentSign = newCurrentSign;
    }


    private IEnumerator BlinkSpeedLimitSign()
    {
        while (true)
        {
            if (currentSign != null) currentSign.SetActive(!currentSign.activeSelf);

            yield return new WaitForSeconds(0.7f);
        }
    }

    private void DeactivateAllSigns()
    {
        if (currentSign != null) currentSign.SetActive(false);
    }
}