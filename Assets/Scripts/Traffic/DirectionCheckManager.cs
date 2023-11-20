using UnityEngine;

public class DirectionCheckManager : MonoBehaviour
{
    private bool collider1Hit = false;
    private bool collider2Hit = false;
    public static int wrongDirectionCount = 0;

    public void ColliderHit(int colliderId)
    {
        if (colliderId == 1)
        {
            if (collider2Hit) 
            {
                wrongDirectionCount++;
                Debug.Log("Kører i forkert retning! Fejl count: " + wrongDirectionCount);
            }
            ResetColliders();
        }
        else if (colliderId == 2)
        {
            collider2Hit = true; 
        }
    }

    private void ResetColliders()
    {
        collider1Hit = false;
        collider2Hit = false;
    }
}
