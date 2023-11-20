using Input;
using Unity.XR.CoreUtils;
using UnityEngine;

public class RecenterOrigin : MonoBehaviour
{
    public Transform Head;
    public Transform Origin;
    public Transform Target;
    
    private IInputManager _inputManager;
    void Start()
    {
        _inputManager = GetComponentInParent<IInputManager>();
        
    }
    

    void Update()
    {
        if (_inputManager.GetRecenterInput())
        {
            Recenter();
        }
        
    }
    
    void Recenter()
    {
        Debug.Log("HEESAESAESASA");
        var rotationAngleY = Target.rotation.eulerAngles.y - Head.transform.rotation.eulerAngles.y ;
        Origin.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = Target.position - Head.transform.position;

        Origin.transform.position += distanceDiff;
    }
    
}
