using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Ball ball;
    public GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {
        cursor.SetActive(true);
        ball.setStartingVelocity();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        
    }

    public void Resume()
    {

    }

    public void RestartLevel()
    {

    }

    public void QuitToTitle()
    {

    }
}
