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

    public void ToggleLeftBlinking()
    {
        ToggleBlinking(ref leftBlinkRoutine, leftArrow);
        StopBlinking(ref rightBlinkRoutine, rightArrow);
        StopBlinking(ref havariblinkRoutine, havariblink);
    }

    public void ToggleRightBlinking()
    {
        ToggleBlinking(ref rightBlinkRoutine, rightArrow);
        StopBlinking(ref leftBlinkRoutine, leftArrow);
        StopBlinking(ref havariblinkRoutine, havariblink);
    }

    public void ToggleHavariBlinking()
    {
        bool isHavariBlinking = havariblinkRoutine != null;
        ToggleBlinking(ref leftBlinkRoutine, leftArrow);
        ToggleBlinking(ref rightBlinkRoutine, rightArrow);

        if (isHavariBlinking)
        {
            StopBlinking(ref havariblinkRoutine, havariblink);
            StopBlinking(ref leftBlinkRoutine, leftArrow);
            StopBlinking(ref havariblinkRoutine, havariblink);
        }
        else
        {
            havariblinkRoutine = StartCoroutine(BlinkArrow(havariblink));
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
