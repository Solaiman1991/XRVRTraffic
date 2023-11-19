using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Car
{
    public class CarDetector : MonoBehaviour
    {
        

        [SerializeField] private float parallelThres = 45f;
        

        public bool ShouldGiveWay(Transform other)
        {
            var otherRot = other.rotation.eulerAngles.y;
            var carRot = transform.rotation.eulerAngles.y;
            
            var diff = Mathf.Abs((otherRot - carRot + 180f) % 360f - 180f);
            return diff < parallelThres;
        }
    }
}