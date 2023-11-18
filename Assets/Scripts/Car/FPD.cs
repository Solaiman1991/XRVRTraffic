using UnityEngine;

public class FPD : MonoBehaviour
{
    public float distance;
    public float mmSpeed = 70;
    public const float minDistance = 10;
    public const float maxDistance = 70;
    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
        distance = maxDistance;
    }

    public float X;
    void FixedUpdate()
    {
       // distance -= Input.GetAxis("Mouse ScrollWheel") * mmSpeed;
        //distance = Mathf.Clamp(distance, minDistance, maxDistance);
        if (distance != camera.fieldOfView) camera.fieldOfView = distance;

/*        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (mouseX != 0 || mouseY != 0)
            RotateView(mouseX, mouseY);
  */
    }

    public float rotateSpeed = 2f;
    private void RotateView(float x, float y)
    {
        x *= rotateSpeed;
        y *= rotateSpeed;

        this.X = transform.eulerAngles.x;
        if (this.X >= 180)
        {
            this.X -= 360;
        }
        if (this.X >= 20)
        {
            this.transform.Rotate(Vector3.left);
        }
        else if (this.X <= -20)
        {
            this.transform.Rotate(Vector3.right);
        }
        else
        {
            this.transform.Rotate(-y, 0, 0);
        }

        this.transform.Rotate(0, x, 0, Space.World);
        Vector3 v3 = this.transform.localRotation.eulerAngles;
        v3.z = 0;
        this.transform.localRotation = Quaternion.Euler(v3);
    }

    public Camera GetCamera()
    {
        return this.camera;
    }
}

