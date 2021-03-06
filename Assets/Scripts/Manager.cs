using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public ElementBehavior[] elements = new ElementBehavior[3];
    [SerializeField] Image[] images;
    [SerializeField] InputField inputTitle, inputDescription;
    public static string inventionNameInManager;
    [SerializeField] Text example;
    [SerializeField] GameObject panel;
    [SerializeField] Image icon;
    [SerializeField] Button paintSceneLoadButton , exapleButton;
    bool isShowing;
    public static bool isScene;
    public bool isChosen;
    public static string  inventionDesc;
    string exampleName;

    public string[] inventions = {"Solar Drone Operator", "Wind Energy Technician", "Urban Agriculture Specialis",
                            "Organizational Disrupter", "Urban Security Coordinator",
                            "Hyper-Intelligent Transportation Engineer", "Artisan Pharmacist",
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

        isScene = true;
            isShowing = false;
            Memory.isReadyToSet = false;
         exapleButton.gameObject.SetActive(false);
            inputTitle.gameObject.SetActive(false);
            inputDescription.gameObject.SetActive(false);
        paintSceneLoadButton.gameObject.SetActive(false);
        panel.SetActive(false);

        }
    private void EnableDrawButton()
    {
       if (inputTitle.text != "" && inputDescription.text != "")
        {
            paintSceneLoadButton.interactable = true;
        }

    }
    private void Update()
    {
        if(isScene == true)
        {
        EnableDrawButton();
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
            if(element)
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

        }
        foreach (MachineEngine machine in FindObjectsOfType<MachineEngine>())
        {
            Destroy(machine.gameObject);
        }
        inputTitle.gameObject.SetActive(true);
        inputDescription.gameObject.SetActive(true);
        paintSceneLoadButton.gameObject.SetActive(true);
        exapleButton.gameObject.SetActive(true);
        SetInvention(inventions[FindObjectOfType<MachineEngine>().row]);
        example.text = inventions[FindObjectOfType<MachineEngine>().row];
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
        inventionNameInManager = value;
        
    }

    public void SetInventionDescription(string value)
    {
        inventionDesc = value;
    }

    public void SetExampleName(/*here put index of the three elements or something*/)  
    {
        //example.text = 
    }

    public void ShowPanel()
    {
        isShowing = !isShowing;
        panel.SetActive(isShowing);
    }

    public void LoadPaintScene()
    {
        SceneManager.LoadScene(1);
        isScene = false;
    }

   
}
