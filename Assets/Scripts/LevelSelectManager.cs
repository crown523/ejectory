using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // there should be a way to find out which button in the sequence was clicked
    // the programatically select the correct scene from the list of scenes in build
    // rather than 10 functions / a switch with 10 statements

    // loadscene works with indices

    public void LoadLevel(Button button)
    {
        SceneManager.LoadScene(button.name);
    }

    public void QuitToTitle()
    {

    }
}
