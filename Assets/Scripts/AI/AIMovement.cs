using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float throttle;
    [SerializeField] private Transform destination;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float throttleLerpTime = 1f;
    [SerializeField] private float stopLerpTime = 0.5f;
    [SerializeField] private float moveSpeed = 4f;
    private Rigidbody _rb;
    private Vector3 direction;
    private bool _stopped = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void SetDestination(Transform dest)
    {
        destination = dest;
    }

    public void ForceStop()
    {
        _stopped = true;
        throttle = 0;
    }

    public void StopCar()
    {
        StartCoroutine(LerpStop());
        _stopped = true;
    }

    public void StartDriving()
    {
        _stopped = false;
        StartCoroutine(LerpAccelerate(moveSpeed));
        
    }

    private void Move()
    {
        AngleToDestination();
        transform.Translate(Vector3.forward * (throttle * Time.deltaTime));
    }

    private void AngleToDestination()
    {
        if (_stopped) return;
        
        Vector3 direction = (destination.position - transform.position).normalized;
        
        float angle = Vector3.Angle(transform.forward, direction);

        if (angle > 15f)
        {
            throttle = moveSpeed / 2;
        }
        else
        {
            throttle = moveSpeed;
        }

    }



    private void Rotate()
    {
        var targetPosition = new Vector3(destination.position.x, transform.position.y, destination.position.z);
        var toRotation = Quaternion.LookRotation(targetPosition - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        //transform.LookAt(new Vector3(destination.position.x, transform.position.y, destination.position.z));
    }

    private IEnumerator LerpStop()
    {
        var startTime = Time.time;
        var currentThrottle = throttle;

        while (Time.time - startTime <= stopLerpTime)
        {
            throttle = Mathf.Lerp(currentThrottle, 0f, (Time.time - startTime) / stopLerpTime);
            yield return null;
        }

        throttle = 0f;
        FreezeRigidBody();
    }

    private void FreezeRigidBody()
    {
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void UnFreezeRigidBody()
    {
        _rb.constraints = RigidbodyConstraints.None;
    }

    private IEnumerator LerpAccelerate(float targetThrottle)
    {
        var startTime = Time.time;
        var initialThrottle = throttle;

        UnFreezeRigidBody();
        while (Time.time - startTime <= throttleLerpTime)
        {
            throttle = Mathf.Lerp(initialThrottle, targetThrottle, (Time.time - startTime) / throttleLerpTime);
            yield return null;
        }

        throttle = targetThrottle;
    }
}