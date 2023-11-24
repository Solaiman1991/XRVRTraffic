using UnityEngine;

public class FPSPrinter : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var fps = 1f / Time.deltaTime;
        Debug.Log("FPS: " + fps);
    }
}