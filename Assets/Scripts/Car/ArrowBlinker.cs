using UnityEngine;
using System.Collections;

public class ArrowBlinker : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject havariblink;

    public float blinkInterval = 0.5f; 

    private Coroutine rightBlinkRoutine;
    private Coroutine leftBlinkRoutine;
    private Coroutine havariblinkRoutine;

    private void Start()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        havariblink.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleBlinking(ref rightBlinkRoutine, rightArrow);
            StopBlinking(ref leftBlinkRoutine, leftArrow);
            StopBlinking(ref havariblinkRoutine, havariblink);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleBlinking(ref leftBlinkRoutine, leftArrow);
            StopBlinking(ref rightBlinkRoutine, rightArrow);
            StopBlinking(ref havariblinkRoutine, havariblink);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleBlinking(ref rightBlinkRoutine, rightArrow);
            ToggleBlinking(ref leftBlinkRoutine, leftArrow);
            ToggleBlinking(ref havariblinkRoutine, havariblink);
        }
    }

    private void ToggleBlinking(ref Coroutine blinkRoutine, GameObject arrow)
    {
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
            arrow.SetActive(false);
            blinkRoutine = null;
        }
        else
        {
            blinkRoutine = StartCoroutine(BlinkArrow(arrow));
        }
    }

    private IEnumerator BlinkArrow(GameObject arrow)
    {
        while (true)
        {
            arrow.SetActive(!arrow.activeSelf);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void StopBlinking(ref Coroutine blinkRoutine, GameObject arrow)
    {
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
            arrow.SetActive(false);
            blinkRoutine = null;
        }
    }
}