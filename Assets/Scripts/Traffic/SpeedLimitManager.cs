using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitManager : MonoBehaviour
{
    public WheelBaseManager WheelBaseManager;


    private float currenctSpeedLimit;
    private GameObject currentSign;
    private Coroutine blinkingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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


    IEnumerator BlinkSpeedLimitSign()
    {
        while (true)
        {
            if (currentSign != null)
            {
                currentSign.SetActive(!currentSign.activeSelf);
            }

            yield return new WaitForSeconds(0.7f);
        }
    }
    
    private void DeactivateAllSigns()
    {
        if (currentSign != null)
        {
            currentSign.SetActive(false);

        }
    }
}
