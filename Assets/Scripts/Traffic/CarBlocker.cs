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
        private List<AIController> cars;
        
       public void BlockCars()
        {
            stopTrigger.SetActive(true);
        }

        public void UnblockCars()
        {
            stopTrigger.SetActive(false);
            StartCoroutine(StartCars());
            cars = new List<AIController>();
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