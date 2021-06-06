using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineEngine : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Transform spawnLoc;
    [SerializeField] ElementBehavior element;
    public int row;
    public bool isStopped;
    float timeInterval;
    float speed;
    int index = 0;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            speed = 0;
            isStopped = true;
       }
    }
    
    public float GetSpeed()
    {
        return speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        row = 0;
        speed = 0.075f;
        // timer = 0;
        ElementBehavior newElement = Instantiate(element, spawnLoc.position , transform.rotation);
        newElement.machine = this;
        
      //  isSpawn = false;

    }

    public Sprite SetSprite()
    {
        
        if (FindObjectOfType<Manager>().GetActiveScene() == 0 )
        {
         index = Random.Range(0, 52);
        }
        else //If in demo
        {
            if(index < 9)
            {
                index++;
            }
            else
            {
                index = 1;
            }
                    
        }
        return sprites[index - 1];
    }

    public void NextObject(float xPos)
    {     
        row++;
        if (row == 9)
        {
            row = 0;
        }
        ElementBehavior newElement =  Instantiate(element, new Vector2(xPos,1.7f), transform.rotation);
        newElement.machine = this;
    }

    //IEnumerator MoveDownward(SpriteRenderer element)
    //{
    //    isStopped = false;
    //    timeInterval = 0.025f;

    //    for (int i = 0; i < 30; i++)
    //    {
    //        if(element.transform.position.y >= -2)
    //        {
    //            element.transform.position = new Vector2(element.transform.position.x, element.transform.position.y - 0.25f);
    //        }
           
    //        else
    //        {
    //            Destroy(element.gameObject);
    //        }

    //        if (element.transform.position.y < 0 && FindObjectsOfType<SpriteRenderer>().Length < 4)
    //        {
    //            NextObject();
    //        }

    //        yield return new WaitForSeconds(timeInterval);
    //    }
    //    //isStopped = true;
       

    //}


    // Update is called once per frame
  


}


