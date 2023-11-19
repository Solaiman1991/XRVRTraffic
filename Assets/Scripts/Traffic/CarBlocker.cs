using System;
using System.Collections;
using System.Collections.Generic;
using AI;
using Unity.VisualScripting;
using UnityEngine;

namespace Traffic
{
    public class CarBlocker : MonoBehaviour
    {
        [SerializeField] private GameObject stopTrigger;
        [SerializeField]
        private bool blockCars = false;
        
        [SerializeField]
        private List<AIController> cars;
        
        // Skal ikke være en update. Bruger update for at toggle lyset manuelt
        private void Update()
        {
            if (blockCars)
            {
                stopTrigger.SetActive(true);
            }
            else
            {
                stopTrigger.SetActive(false);
                StartCoroutine(StartCars());
            }
        }

        private IEnumerator StartCars()
        {
            foreach (var car in cars)
            {
                car.StartCar();
                yield return new WaitForSeconds(2f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("AI"))
            {
                cars.Add(other.GetComponent<AIController>());
            }
        }
    }
}