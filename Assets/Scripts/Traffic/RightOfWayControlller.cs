using System.Collections;
using Traffic;
using UnityEngine;

public class RightOfWayControlller : MonoBehaviour
{
    [SerializeField] private CarBlocker blockZone1, blockZone2;
    [SerializeField] private Transform centerPoint;
    private GameObject _currentlyTracked;

    private readonly float _distanceTrackerThreshold = 20f;
    private float _lastDistance = 50f;
    private readonly WaitForSeconds _wait = new(1);

    private void Update()
    {
        HandleTrackedCar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("AI") && !other.CompareTag("Car")) return;
        if (!ShouldTrackCar(other.transform)) return;

        _currentlyTracked = other.gameObject;
        EnableBlockers();
    }

    private void EnableBlockers()
    {
        blockZone1.BlockCars();
        blockZone2.BlockCars();
    }

    private IEnumerator StartCars()
    {
        blockZone1.UnblockCars();
        yield return _wait;
        blockZone2.UnblockCars();
    }

    private bool ShouldTrackCar(Transform other)
    {
        var distance = Vector3.Distance(other.position, centerPoint.position);
        return distance > _distanceTrackerThreshold;
    }

    private void StopTracking()
    {
        _lastDistance = 50f;
        _currentlyTracked = null;
        StartCoroutine(StartCars());
    }

    private void HandleTrackedCar()
    {
        if (_currentlyTracked == null) return;
        var currentDistance = Vector3.Distance(_currentlyTracked.transform.position, centerPoint.position);
        Debug.Log("currentDis: " + currentDistance);
        if (currentDistance <= _lastDistance)
        {
            _lastDistance = currentDistance;
            return;
        }

        StopTracking();
    }
}