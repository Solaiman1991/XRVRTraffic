
using System;
using System.Collections;
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
        [SerializeField]
        private MenuManager _menuManager;
        private AIMovement _movement;
        
        [SerializeField] private AiRoute _route;
        
        [SerializeField] private float nodeDistanceThreshold;
        [SerializeField] private float distanceToDest;
        [SerializeField] private Transform currentNode;

        [SerializeField] private GameObject carInFront;

        private Vector3 _initialPosition;
        private Quaternion _initialRotation;

        private void Awake()
        {
            _movement = GetComponent<AIMovement>();
        }

        private void Start()
        {
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("AI"))
            {
                StartCoroutine(ResetCar());
            } else if (collision.gameObject.CompareTag("Car"))
            {
                _menuManager.GameOver();
            }
        }

        private IEnumerator ResetCar()
        {
            _movement.ForceStop();
            transform.rotation = _initialRotation;
            transform.position = _initialPosition;
            _route.ResetRoute();
            currentNode = _route.GetCurrentNode();
            yield return new WaitForSeconds(2f);
            _movement.StartDriving();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("AI") || other.CompareTag("Car") )
            {
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
