using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HSVPicker.Examples
{

public class BrushController : MonoBehaviour
{
    Vector2 mouseWorldPos;
    [SerializeField] Camera cam;
    LineRenderer LR;
    bool isFirstPoint;
    public ColorPickerTester CPT;
    public GameObject sacrifice, brushM;
    Color currentColor;
    // Start is called before the first frame update
    void Awake()
    {
        LR = GetComponent<LineRenderer>();
        isFirstPoint = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
            if (!GameManager.isUsingUI)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
                    AddPoints(mouseWorldPos);
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    GameObject brushClone = Instantiate(gameObject, transform.position, Quaternion.identity);
                    brushClone.GetComponent<BrushController>().enabled = false;
                    LR.positionCount = 2;
                    isFirstPoint = true;
                }

            }
    }
       


    void AddPoints(Vector2 mousePos)
    {
        if (!isFirstPoint)
        {
            LR.positionCount++;
            LR.SetPosition(LR.positionCount - 1, mousePos);
        }
        else
        {
            LR.SetPosition(0, mousePos);
            LR.SetPosition(1, mousePos);
            isFirstPoint = false;
        }

    }
}
}
