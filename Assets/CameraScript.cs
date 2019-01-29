using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    void OnPreCull()
    {
        Camera camera = GetComponent<Camera>();
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }

    void OnPreRender()
    {
        GL.invertCulling = true;
    }

    void OnPostRender()
    {
        GL.invertCulling = false;
    }

}
