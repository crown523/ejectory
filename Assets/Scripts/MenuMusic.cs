using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
