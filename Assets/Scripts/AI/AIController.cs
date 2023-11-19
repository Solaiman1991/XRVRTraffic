
using System;
using Car;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private AiRoute _route;
        [SerializeField] private AIMovement _movement;
        private CarDetector _carDetector;
        [SerializeField] private float distanceThreshold;
        [SerializeField] private float distanceToDest;
        [SerializeField]
        private Transform currentNode;

        [SerializeField] private GameObject carInFront;
        [SerializeField] private float minDistanceThreshold = 5f;

        private bool isDriving;
        
        private void Awake()
        {
            _carDetector = GetComponentInChildren<CarDetector>();
        }

        private void Start()
        {
            currentNode = _route.GetCurrentNode();
            _movement.SetDestination(currentNode);
        }

        private void Update()
        {
            
            HandleDetectedCars();
            UpdateMovement();
            if (!IsAtCurrentNode()) return;
            currentNode = _route.GetNextNode();
            
        }

        private void UpdateMovement()
        {
            _movement.SetDestination(currentNode);
            SetSpeed();
        }

        private bool IsAllowedToDrive()
        {
            return true;
        }

        private void HandleDetectedCars()
        {
            carInFront = _carDetector.GetClosestsParallelCar();
            
        }

        private void SetSpeed()
        {
            if (carInFront is not null && isDriving)
            {
                var distance = Vector3.Distance(carInFront.transform.position, transform.position);
                if (distance <= minDistanceThreshold)
                {
                    Debug.Log("Stopping car");
                    _movement.StopCar();
                    isDriving = false;
                }
                return;
            }

            if (carInFront is null && !isDriving)
            {
                Debug.Log("Starting to drive");
                _movement.StartDriving();
                isDriving = true;
                return;
            }
            
        }

        private bool IsAtCurrentNode()
        {
            distanceToDest = Vector3.Distance(transform.position, currentNode.position);
            return distanceToDest < distanceThreshold;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Car")) return;
            
            if (_carDetector.IsCarInFront(other.transform))
            {
                carInFront = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Car"))
            {
                if (other.name == carInFront.name && carInFront is not null)
                {
                    carInFront == null;
                }
            }
        }
    }
}
