using UnityEngine;

public class SpeedLimitSignController : MonoBehaviour
{
    public GameObject speedLimitSign;
    public SpeedLimitManager speedLimitManager;

    [SerializeField] private float SpeedThreshold = 30f;


    void Start()
    {
    }


    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            speedLimitManager.SetSpeedLimit(SpeedThreshold, speedLimitSign);
        }
    }
}
