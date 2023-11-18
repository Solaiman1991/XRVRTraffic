using Input;
using Unity.VisualScripting;
using UnityEngine;

public class WheelBaseManager : MonoBehaviour
{
    private IInputManager _inputManager;

    public Transform flDiscBrake, frDiscBrake;

    private WheelBase _wheelBase;
    
    [Header("This is the actual running speed of the car (KM/H)")]
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GetComponent<IInputManager>();
        _wheelBase = GetComponent<WheelBase>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        _wheelBase.ApplySteering(_inputManager.GetSteeringInput(), speed);
        _wheelBase.ApplyBreak(_inputManager.GetBrakeInput());
        _wheelBase.ApplyThrottle(_inputManager.GetThrottleInput());
        RotateWheel();
    }
    
    private void RotateWheel()
    {
        // Front wheels (child objects)
        flDiscBrake.Rotate(_wheelBase.FLWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);
        frDiscBrake.Rotate(_wheelBase.FRWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);
        // Rear wheels
        _wheelBase.RRWheel.Transform.Rotate(_wheelBase.RRWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);
        _wheelBase.RLWheel.Transform.Rotate(_wheelBase.RLWheel.Collider.rpm * 6 * Time.deltaTime * Vector3.right);

        // Car speed
        speed = _wheelBase.FLWheel.Collider.rpm * (_wheelBase.FLWheel.Collider.radius * 2 * Mathf.PI) * 60 / 1000;

        // Speed - remove decimal points
        speed = Mathf.Round(speed);
    }
}
