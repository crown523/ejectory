using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: when cursor object is active, hide the actual cursor
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
        cursor.SetActive(false);
        ball.SetActive(false);
        box.SetActive(false);
        goal.SetActive(false);
        StartCoroutine(PlayTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayTutorial()
    {
        textBox.SetActive(true);
        StartCoroutine(CreateNotif("Welcome to ejectory.", 3));
        yield return new WaitForSeconds(3);
        cursor.SetActive(true);
        StartCoroutine(CreateNotif("In this game, you wield the power to lock objects in time and manipulate their trajectories.", 3));
        yield return new WaitForSeconds(3);
        textBox.SetActive(false);
        box.SetActive(true);
        cursor.SetActive(true);
        yield return new WaitForSeconds(2);
        textBox.SetActive(true);
        StartCoroutine(CreateNotif("This is a lockable object. When your cursor is in the locking mode (represented by a lock), "
        + "you can left click a lockable object to freeze it in time.", 7));
        yield return new WaitForSeconds(7);
        StartCoroutine(CreateNotif("When an object is locked, you can right click to switch to hammer mode. " 
        + "In hammer mode, hitting a locked object applies a force to it correspondingly. Try it out!", 7));
        yield return new WaitForSeconds(7);
        textBox.SetActive(false);
        yield return new WaitForSeconds(15);
        box.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.SetActive(true);
        goal.SetActive(true);
        textBox.SetActive(true);
        StartCoroutine(CreateNotif("In each level, your goal is to manipulate lockable objects in order to move the ball (which is not lockable) into the goal (green portal).", 7));
        yield return new WaitForSeconds(7);
        StartCoroutine(CreateNotif("Complete this level to move on!", 3));
        yield return new WaitForSeconds(3);
        textBox.SetActive(false);
    }

    IEnumerator CreateNotif(string msg, int time)
    {
        notifText.text = msg;
        yield return new WaitForSeconds(time);
        notifText.text = "";
    }


}
