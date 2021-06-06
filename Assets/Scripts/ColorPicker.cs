using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Paint.currentColor = GetComponent<SpriteRenderer>().color;
        DotManager.order += 1;
    }
}
