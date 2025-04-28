using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCameraCapture : MonoBehaviour
{
    public Camera arCamera;

    public Texture2D CaptureFrame()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        arCamera.targetTexture = rt;
        Texture2D screen = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        arCamera.Render();
        RenderTexture.active = rt;
        screen.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screen.Apply();
        arCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        return screen;
    }
}
