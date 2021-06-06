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
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetKey(KeyCode.Mouse0))
        {
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
        fuckit = Resources.Load<Sprite>("Sprite/CameraScreenshot");
        yield return new WaitUntil(() => fuckit != null);
        SceneManager.LoadScene(2);
    }
}
