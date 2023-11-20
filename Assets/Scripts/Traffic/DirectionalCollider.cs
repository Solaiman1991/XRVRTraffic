using UnityEngine;

public class DirectionalCollider : MonoBehaviour
{
    public DirectionCheckManager manager;
    public int colliderId; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            manager.ColliderHit(colliderId);
        }
    }
}
