using UnityEngine;

public class TurnLeftCheckCollider : MonoBehaviour
{
    public TurnLeftCheckManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) manager.ColliderHit(gameObject.name);
    }
}