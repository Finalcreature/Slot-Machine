using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Paint : MonoBehaviour
{
    public Slider slider;
    public Transform baseDot;
    public static string toolType;
    public static Color currentColor;
    public static Vector2 localScale;
    public Camera camera;
    int value;

    public Sprite fuckit;
    // Start is called before the first frame update
   
    
    // Update is called once per frame
    void Update()
    {
        localScale = new Vector2(slider.value, slider.value);
        if (Input.touchCount > 0)
        {
            Vector2 mousePos = Input.GetTouch(0).position;
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(baseDot, objPosition, transform.rotation);
        }
       
          
      
    }
   public void EndScene()
    {
        camera.GetComponent<Camera>().orthographicSize = 2.8f;
        ScreenShotCamera.TakeScreenShotInGame(500, 500);
        StartCoroutine(GetSprite());
    }
    IEnumerator GetSprite()
    {
       
        yield return new WaitForSeconds(2);
        fuckit = Resources.Load<Sprite>("Sprite/CameraScreenshot");
        SceneManager.LoadScene(2);
    }
}
