using UnityEngine;
using Violation;

public class TurnLeftCheckManager : MonoBehaviour
{
    public static int failureCount;
    public ArrowBlinker arrowBlinker;
    private ViolationManager _violationManager;
    private bool firstColliderHit;
    private bool secondColliderHit;

    private void Start()
    {
        _violationManager = FindFirstObjectByType<ViolationManager>();
    }

    public void ColliderHit(string colliderName)
    {
        if (colliderName == "Collider1")
        {
            firstColliderHit = true;
        }
        else if (colliderName == "Collider2")
        {
            secondColliderHit = true;
            CheckTurnIndicator();
        }
    }

    private void CheckTurnIndicator()
    {
        if (firstColliderHit && secondColliderHit)
        {
            if (!IsCorrectIndicatorOn())
            {
                failureCount++;
                _violationManager.OnIndicatorViolation();
                Debug.Log("Blinklys venstre fejl count: " + failureCount);
            }

            ResetColliders();
        }
    }

    private bool IsCorrectIndicatorOn()
    {
        return arrowBlinker.IsLeftBlinking();
    }

    private void ResetColliders()
    {
        firstColliderHit = false;
        secondColliderHit = false;
    }
}