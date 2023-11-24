using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> cars;

    private void Awake()
    {
        cars = GameObject.FindGameObjectsWithTag("Car").ToList();
    }
}