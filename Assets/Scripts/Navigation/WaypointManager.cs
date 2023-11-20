using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Navigation
{
    public class WaypointManager : MonoBehaviour
    {
        private Transform arrowsTransform;
        public List<GameObject> arrows = new();
        void Start()
        {
            arrowsTransform = transform.Find("Arrows");
            foreach (Transform child in arrowsTransform)
            {
                if (child.CompareTag("Arrow"))
                {
                    arrows.Add(child.gameObject);
                }
            }
        }

        public ArrowDirection.Direction OnWaypointEntered(string waypointName)
        {
            var waypointIndex = GetNumber(waypointName);
            foreach (var arrow in arrows.Where(arrow => waypointIndex == GetNumber(arrow.name)))
            {
                arrow.SetActive(true);
                if (waypointIndex > 1)
                {
                    arrows[waypointIndex - 2].SetActive(false);
                }
            }
            return arrows[waypointIndex - 1].GetComponent<ArrowDirection>().GetDirection();
        }

        private int GetNumber(string objectName)
        {
            var resultString = Regex.Match(objectName, @"\d+").Value;
            return int.Parse(resultString);
        }
    }
}
