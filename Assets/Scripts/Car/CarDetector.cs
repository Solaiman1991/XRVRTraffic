using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Car
{
    public class CarDetector : MonoBehaviour
    {
        private Dictionary<string, GameObject> cars = new();

        [SerializeField] private float parallelThres = 25f;
        
        
        private List<GameObject> GetParallelTraffic()
        {
            List<GameObject> list = new List<GameObject>();
            foreach (var car in cars)
            {
                var rotation = car.Value.transform.rotation.eulerAngles.y;
                var trans = transform.rotation.eulerAngles.y;
                var diff = Mathf.Abs((rotation - trans + 180f) % 360f - 180f);

                if (diff < parallelThres) list.Add(car.Value);
            }
            return list;
        }

        public GameObject GetClosestsParallelCar()
        {
            var list = GetParallelTraffic();
            if (list.Count == 0) return null;
            
            GameObject closest = list[0];
            float closestDiff = Vector3.Distance(transform.position, closest.transform.position);
            for (int i = 1; i < list.Count; i++)
            {
                var diff = Vector3.Distance(transform.position, list[i].transform.position);
                if ( diff < closestDiff)
                {
                    closest = list[i];
                    closestDiff = diff;
                }
            }
            return closest;
        }

        public bool IsCarInFront(Transform other)
        {
            var otherRot = other.rotation.eulerAngles.y;
            var carRot = transform.rotation.eulerAngles.y;
            
            var diff = Mathf.Abs((otherRot - carRot + 180f) % 360f - 180f);
            return diff < parallelThres;
        }

        public void AddCar(GameObject gameObject)
        {
            Debug.Log("Adderd car");
            cars.Add(gameObject.name, gameObject);
        }

        public void RemoveCar(GameObject gameObject)
        {
            Debug.Log("Removed car");
            cars.Remove(gameObject.name);
        }
    }
}