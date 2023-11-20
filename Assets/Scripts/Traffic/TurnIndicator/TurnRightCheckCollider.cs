using UnityEngine;

public class TurnRightCheckCollider : MonoBehaviour
{
    public TurnRightCheckManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {

            manager.ColliderHit(gameObject.name);
        }
    }
}
