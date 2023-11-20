using UnityEngine;

public class TurnRightCheckManager : MonoBehaviour
{
    public ArrowBlinker arrowBlinker;
    private bool firstColliderHit = false;
    private bool secondColliderHit = false;
    public static int failureCount = 0;

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
                Debug.LogWarning("Blinklys højre fejl count: " + failureCount);
            }
            ResetColliders();
        }
    }

    private bool IsCorrectIndicatorOn()
    {
        return arrowBlinker.IsRightBlinking();
    }

    private void ResetColliders()
    {
        firstColliderHit = false;
        secondColliderHit = false;
    }
}
