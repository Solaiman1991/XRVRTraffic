using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class Retroreflector_MirrorFlip : MonoBehaviour
{
    public bool flipHorizontal;
    private new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        GL.invertCulling = false;
    }

    private void OnPreCull()
    {
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();
        var scale = new Vector3(flipHorizontal ? -1 : 1, 1, 1);
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(scale);
    }

    private void OnPreRender()
    {
        GL.invertCulling = flipHorizontal;
    }
}