using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBehavior : MonoBehaviour
{
    bool isSpawned;
    public MachineEngine machine;
    float speed;
    static int index = 0;
    Manager manager;
    //bool isStopped
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        name = machine.row.ToString();
        speed = machine.GetSpeed();
        isSpawned = false;
        GetComponent<SpriteRenderer>().sprite = machine.SetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -4)
        {
            transform.Translate(Vector3.down * speed);
            if (machine.isStopped)
            {
                StartCoroutine("SetSpeed");
            }
        }
        else
        {
            Destroy(gameObject);
        }

        if (transform.position.y < 0 && !isSpawned && !machine.isStopped)
        {
            machine.NextObject(transform.position.x);
            isSpawned = true;
        }  
    }

    IEnumerator SetSpeed()
    {
     
        yield return new WaitUntil(() => transform.position.y < 0 == true);
        speed = machine.GetSpeed();

        
        {
            foreach (ElementBehavior element in FindObjectsOfType<ElementBehavior>())
            {
                if (element.name != (machine.row).ToString())
                {
                    Destroy(element.gameObject);
                }
            }

            yield return new WaitForSeconds(3);

            transform.position = Vector2.MoveTowards(transform.position,
                                                     new Vector2(transform.position.x, -3), Time.deltaTime);
            GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;


            
            yield return new WaitUntil(() => transform.position.y == -3);
            if(index < 3)
            {
                manager.elements[index] = this;
                index++;
            }
            manager.SetImages();
            //Memory.isReadyToSet = true;
            machine.isStopped = false;
        }
        
        
    }
}
