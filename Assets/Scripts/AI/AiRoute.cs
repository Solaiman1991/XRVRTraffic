using System.Collections.Generic;
using UnityEngine;

public class AiRoute : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;

    [SerializeField] private int currentNodeIndex;

    private void Awake()
    {
        foreach (Transform child in transform) waypoints.Add(child);
    }

    private void UpdateRoute()
    {
        Debug.Log("Updating route to next index");
        currentNodeIndex = (currentNodeIndex + 1) % waypoints.Count;
    }

    public void ResetRoute()
    {
        currentNodeIndex = 0;
    }

    public Transform GetCurrentNode()
    {
        return waypoints[currentNodeIndex];
    }

    public Transform GetNextNode()
    {
        UpdateRoute();
        return GetCurrentNode();
    }
}