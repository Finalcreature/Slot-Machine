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
    public string inventionName;
    [SerializeField] Text example;
    [SerializeField] GameObject panel;
    [SerializeField] Image icon;
    bool isShowing;
    public bool isChosen;

    public string[] inventions = {"Solar-based Drone", "Wind Energy Technician", "Urban Agriculture Specialis",
                            "Organizational Disrupter", "Urban Security Coordinator",
                            "Hyper-Intelligent Transportation Engineer", "Pharmaceutical Artisan",
                            "Extinct Species Revivalist", "Personal Education Guide", "Personal Health Lifestyle Guide" };
    [SerializeField] Sprite[] icons;
    public void GetNewTitleText(string inputText)
    {
        LikeManager.inputTitleText = inputText;
    }
    public void GetDiscribeText(string inputText)
    {
        LikeManager.inputDiscribeText = inputText;
    }
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
            isShowing = false;
            Memory.isReadyToSet = false;
            input.gameObject.SetActive(false);
            panel.SetActive(false);

        }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }
        if (Memory.isReadyToSet)
        {
            Memory.isReadyToSet = false;
        }
        //    foreach (ElementBehavior element in elements)
        //    {
        //        if(element.machine.name == "Slot Machine")
        //        {
        //            images[0].sprite = element.GetComponent<SpriteRenderer>().sprite;
        //        }
        //        else if(element.machine.name == "Slot Machine (1)")
        //        {
        //            images[1].sprite = element.GetComponent<SpriteRenderer>().sprite;
        //        }
        //        else
        //        {
        //            images[2].sprite = element.GetComponent<SpriteRenderer>().sprite;
        //        }

        //        Destroy(element.gameObject);
        //    }
        //    foreach (MachineEngine machine in FindObjectsOfType<MachineEngine>())
        //    {
        //        Destroy(machine.gameObject);
        //    }
        //    input.gameObject.SetActive(true);

            
        //}


    }

    public void SetImages()
    {
        foreach (ElementBehavior element in elements)
        {
            if (element.machine.name == "Slot Machine")
            {
                images[0].sprite = element.GetComponent<SpriteRenderer>().sprite;
            }
            else if (element.machine.name == "Slot Machine (1)")
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

        SetInvention(inventions[FindObjectOfType<MachineEngine>().row]);
        icon.sprite = icons[FindObjectOfType<MachineEngine>().row];

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        
    }

    public int GetActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SetInvention(string value)
    {      
        inventionName = value;
        example.text = value;
        
    }

    public void ShowPanel()
    {
        isShowing = !isShowing;
        panel.SetActive(isShowing);
    }
}
