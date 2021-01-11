using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : MonoBehaviour
{
    //private bool moving;
    private Rigidbody2D body;
    private bool locked;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //moving = false;

        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector3(0.0f, speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!moving && Input.GetKeyDown("space"))
        {
            
        }
        */

        //print(body.velocity.y);

    }
}
