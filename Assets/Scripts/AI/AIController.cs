
using System;
using Car;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace AI
{
    [RequireComponent(typeof(AIMovement))]
    public class AIController : MonoBehaviour
    {
        private AIMovement _movement;
        private CarDetector _carDetector;
        [SerializeField] private AiRoute _route;
        
        [SerializeField] private float nodeDistanceThreshold;
        [SerializeField] private float distanceToDest;
        [SerializeField] private Transform currentNode;

        [SerializeField] private GameObject carInFront;

        private void Awake()
        {
            _carDetector = GetComponentInChildren<CarDetector>();
            _movement = GetComponent<AIMovement>();
        }

        private void Start()
        {
            currentNode = _route.GetCurrentNode();
            _movement.SetDestination(currentNode);
            StartCar();
        }

        private void Update()
        {
            if (!IsAtCurrentNode()) return;
            SetNewTargetPosition();
        }

        private void SetNewTargetPosition()
        {
            currentNode = _route.GetNextNode();
            _movement.SetDestination(currentNode);
            
        }
        
        private bool IsAtCurrentNode()
        {
            distanceToDest = Vector3.Distance(transform.position, currentNode.position);
            return distanceToDest < nodeDistanceThreshold;
        }

        public void StopCar()
        {
            _movement.StopCar();
        }

        public void StartCar()
        {
            _movement.StartDriving();
        }
        

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("AI") )
            {
                // if (!_carDetector.ShouldGiveWay(other.transform))
                // {
                //     Debug.Log("Other car seems to not be going in the same direction");
                //     return;
                // }

                carInFront = other.gameObject;
                StopCar();
            } else if (other.CompareTag("StopTrigger"))
            {
                Debug.Log("Should stop for red light");
                StopCar();
            }
        }
        

        private void OnTriggerExit(Collider other)
        {
            if (carInFront == null) return;
            if (other.name == carInFront.name)
            {
                StartCar();
            } 
        }
    }
}
