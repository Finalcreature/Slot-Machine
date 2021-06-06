using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LikeManager : MonoBehaviour
{

    public Text[] likes = new Text[2];
    public Text[] newTitleText = new Text[2];
    int like;
    int disLike;
    float timer;
    bool isLike = true;

    public static string inputTitleText;
    public static string inputDiscribeText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inputTitleText);
        newTitleText[0].text = inputTitleText;
        newTitleText[1].text = inputDiscribeText;
        like = 0;
        disLike = 0;
        timer = 0;
      //  likes[2].text = FindObjectOfType<Manager>().inventions[MachineEngine.row];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < 30)
        {
            if ((int)timer % 2 == 0 && isLike == true && timer > 0)
            {
                isLike = false;
                like += Random.Range(0, 6);
                disLike += Random.Range(0, 3);
                StartCoroutine(GetTrue());
            }
            
        }
        likes[0].text = like.ToString();
        likes[1].text = disLike.ToString();
    }
    IEnumerator GetTrue()
    {
        yield return new WaitForSeconds(1.7f);
        isLike = true;
    }
}
