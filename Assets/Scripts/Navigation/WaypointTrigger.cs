using Car;
using UnityEngine;

namespace Navigation
{
    public class WaypointTrigger : MonoBehaviour
    {
        private ArrowDirection.Direction arrowDirection;
        private DrivingInstructorAudioManager audioManager;
        private WaypointManager waypointManager;

        private void Start()
        {
            waypointManager = GetComponentInParent<WaypointManager>();
            audioManager = FindFirstObjectByType<DrivingInstructorAudioManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Car"))
            {
                arrowDirection = waypointManager.OnWaypointEntered(name);
                switch (arrowDirection)
                {
                    case ArrowDirection.Direction.Left:
                        audioManager.PlayTurnLeft();
                        break;
                    case ArrowDirection.Direction.Right:
                        audioManager.PlayTurnRight();
                        break;
                    case ArrowDirection.Direction.Stop:
                        audioManager.PlayPark();
                        break;
                }
            }
        }
    }
}