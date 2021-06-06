using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(gameObject.name == "Eraser")
        {
        Paint.toolType = "Eraser";
        }
        else if(gameObject.name == "Brush")
        {
            Paint.toolType = "Paint";
        }
        
    }
}
