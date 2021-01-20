using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject cursor;
    public GameObject ball;
    public GameObject box;
    public GameObject goal;

    // ui
    public Text notifText;
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayTutorial());
        cursor.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayTutorial()
    {
        yield return new WaitForSeconds(4);
    }

    IEnumerator CreateNotif(string msg, int time)
    {
        notifText.text = msg;
        yield return new WaitForSeconds(time);
        notifText.text = "";
    }


}
