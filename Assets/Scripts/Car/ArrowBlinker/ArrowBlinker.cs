using System.Collections;
using UnityEngine;

public class ArrowBlinker : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject havariblink;

    public float blinkInterval = 0.5f;
    private Coroutine havariblinkRoutine;
    private bool isLeftBlinking;

    private bool isRightBlinking;
    private Coroutine leftBlinkRoutine;

    private Coroutine rightBlinkRoutine;

    private void Start()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        havariblink.SetActive(false);
    }

    public void ToggleLeftBlinking()
    {
        isLeftBlinking = !isLeftBlinking;
        ToggleBlinking(ref leftBlinkRoutine, leftArrow);
        StopBlinking(ref rightBlinkRoutine, rightArrow);

        if (havariblinkRoutine != null) StopBlinking(ref havariblinkRoutine, havariblink);
    }

    public void ToggleRightBlinking()
    {
        isRightBlinking = !isRightBlinking;
        ToggleBlinking(ref rightBlinkRoutine, rightArrow);
        StopBlinking(ref leftBlinkRoutine, leftArrow);
        if (havariblinkRoutine != null) StopBlinking(ref havariblinkRoutine, havariblink);
    }

    public void ToggleHavariBlinking()
    {
        if (havariblinkRoutine != null)
            StopBlinking(ref havariblinkRoutine, havariblink);
        else
            havariblinkRoutine = StartCoroutine(BlinkArrow(havariblink));
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

    public bool IsRightBlinking()
    {
        return isRightBlinking;
    }

    public bool IsLeftBlinking()
    {
        return isLeftBlinking;
    }
}