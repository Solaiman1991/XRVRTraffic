using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIMovement : MonoBehaviour
{
    [SerializeField] private float throttle;
    [SerializeField] private Transform destination;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float throttleLerpSpeed = 5f;
    [SerializeField] private float moveSpeed = 4f;
    private Vector3 direction;
    
    

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void SetDestination(Transform dest)
    {
        destination = dest;
    }

    public void StopCar()
    {
        StopCoroutine("LerpThrottle");
        StartCoroutine(LerpThrottle(0f));
        
    }

    public void StartDriving()
    {
        
        StartCoroutine(LerpThrottle(moveSpeed));
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (throttle * Time.deltaTime));
    }

    private void Rotate()
    {
        transform.LookAt(new Vector3(destination.position.x, transform.position.y, destination.position.z));
    }
    
    private IEnumerator LerpThrottle(float targetThrottle)
    {
        var startTime = Time.time;
        var initialThrottle = throttle;

        while (Time.time - startTime <= throttleLerpSpeed)
        {
            throttle = Mathf.Lerp(initialThrottle, targetThrottle, (Time.time - startTime) / throttleLerpSpeed);
            yield return null;
        }

        // Ensure the final value is exactly the target value
        throttle = targetThrottle;
    }

}
