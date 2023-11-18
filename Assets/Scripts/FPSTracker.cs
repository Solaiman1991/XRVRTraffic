using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    private void Update()
    {
        var fps = (1f / Time.deltaTime);
        Debug.Log("FPS: " + fps);
    }
}