using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotManager : MonoBehaviour
{
    public static int order;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = order;
        GetComponent<Transform>().localScale = new Vector2(transform.localScale.x + Paint.localScale.x , transform.localScale.y + Paint.localScale.y);
        if (Paint.currentColor.a == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
        GetComponent<SpriteRenderer>().color = Paint.currentColor;
        }
    }
    private void OnMouseOver()
    {
        if(Paint.toolType == "Eraser")
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Tool")
        {
            Destroy(gameObject);
        }
    }
}
