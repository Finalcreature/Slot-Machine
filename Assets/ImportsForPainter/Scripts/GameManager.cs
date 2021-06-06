using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LineRenderer LR;
    public Scrollbar SB;
    public static bool isUsingUI;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
