using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewIconSprite : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("CameraScreenshot");
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
