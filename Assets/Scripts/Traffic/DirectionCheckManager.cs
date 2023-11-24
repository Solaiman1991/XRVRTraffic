using UnityEngine;

public class DirectionCheckManager : MonoBehaviour
{
    public static int wrongDirectionCount;
    public GameObject WrongDirectionSign;
    private bool collider1Hit;
    private bool collider2Hit;

    public void ColliderHit(int colliderId)
    {
        if (colliderId == 1)
        {
            if (collider2Hit)
            {
                wrongDirectionCount++;
                WrongDirectionSign.SetActive(true);

                Debug.LogWarning("Kører i forkert retning! Fejl count: " + wrongDirectionCount);
            }
            else
            {
                WrongDirectionSign.SetActive(false);
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