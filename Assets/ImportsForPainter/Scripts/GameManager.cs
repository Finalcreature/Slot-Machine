using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LineRenderer LR;
    public Scrollbar SB;
    public static bool isUsingUI;
    public static Texture2D capturedLogo;
    public Image previewLogo;
    [SerializeField] GameObject picker;
    [SerializeField] Button button1;
    [SerializeField] Scrollbar scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        previewLogo.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLineWidth()
    {
        LR.widthMultiplier = SB.value;
    }

    public void IsInRange()
    {
        isUsingUI = true;
    }
    public void IsOutOfRange()
    {
        isUsingUI = false;
    }
    public void FinishLogo()
    {
        StartCoroutine(SayCheese());
    }

    IEnumerator SayCheese()
    {
        picker.SetActive(false);
        button1.gameObject.SetActive(false);
        scrollbar.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        capturedLogo = ScreenCapture.CaptureScreenshotAsTexture();
        previewLogo.gameObject.SetActive(true);
        previewLogo.GetComponent<Image>().sprite = Sprite.Create(capturedLogo, new Rect(0, 0, capturedLogo.width, capturedLogo.height), new Vector2(0.5f, 0.5f));
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);

    }
}
