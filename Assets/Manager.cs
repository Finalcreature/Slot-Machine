using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public ElementBehavior[] elements = new ElementBehavior[3];
    [SerializeField] Image[] images;
    [SerializeField] InputField input;
    string inventionName;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Manager>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

        void Start()
        {
         Memory.isReadyToSet = false;
         input.gameObject.SetActive(false);

        }

    private void Update()
    {
        if (Memory.isReadyToSet)
        {
            Memory.isReadyToSet = false;
            foreach (ElementBehavior element in elements)
            {
                if(element.machine.name == "Slot Machine")
                {
                    images[0].sprite = element.GetComponent<SpriteRenderer>().sprite;
                }
                else if(element.machine.name == "Slot Machine (1)")
                {
                    images[1].sprite = element.GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    images[2].sprite = element.GetComponent<SpriteRenderer>().sprite;
                }

                Destroy(element.gameObject);
            }
            foreach (MachineEngine machine in FindObjectsOfType<MachineEngine>())
            {
                Destroy(machine.gameObject);
            }
            input.gameObject.SetActive(true);

            
        }


    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        
    }

    public int GetActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SetName(string value)
    {      
        inventionName = value;
        print(inventionName);
    }
}
