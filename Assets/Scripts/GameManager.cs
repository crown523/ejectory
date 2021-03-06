﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// TODO: when cursor object is active, hide the actual cursor

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public GameObject cursor;
    public GameObject initialIndicatorArrow;
    public AudioSource musicPlayer;

    // ui
    public GameObject pauseMenu;
    public GameObject startLevelButton;

    // state
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        startLevelButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown("r"))
        {
            RestartLevel();
        }
    }

    public void StartLevel()
    {
        cursor.SetActive(true);
        startLevelButton.SetActive(false);
        ball.setStartingVelocity();
        if (initialIndicatorArrow != null)
        {
            initialIndicatorArrow.SetActive(false);
        }
        musicPlayer.Play(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void RestartLevel()
    {
        Debug.Log("restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
