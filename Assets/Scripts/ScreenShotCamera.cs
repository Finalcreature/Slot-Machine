using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotCamera : MonoBehaviour
{
    private static ScreenShotCamera instance;
    Camera myCamera;
    bool takeScreenShotOnNextFrame;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        myCamera = GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if (takeScreenShotOnNextFrame)
        {
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTextuer = myCamera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTextuer.width, renderTextuer.height  , TextureFormat.ARGB32 , false);
            Rect rect = new Rect(0, 0, renderTextuer.width, renderTextuer.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Resources/Sprite/CameraScreenshot.png" , byteArray);
            RenderTexture.ReleaseTemporary(renderTextuer);
            myCamera.targetTexture = null;
        }
    }
   private void TakeScreenShot(int width , int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
    }
    public static void TakeScreenShotInGame(int width , int height)
    {
        instance.TakeScreenShot(width, height);
    }
  
}
