using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : MonoBehaviour
{
    //private bool moving;
    private Rigidbody2D body;
    private bool locked;
    private float timeWhenLocked;
    private Vector3 newVelocity;

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

        if (Time.time - timeWhenLocked > 3) // locks last 3 seconds
        {
            locked = false;
            body.velocity = newVelocity;
            body.velocity = new Vector3(2, 2, 0); // for debug
        }

    }

    public void Lock()
    {
        if (!locked)
        {
            locked = true;
            timeWhenLocked = Time.time;
            print("locked");
            body.velocity = new Vector3(0,0,0); // kill movement
        }
        
    }

    public void ApplyMomentum()
    {
        if (locked)
        {
            print("touched");
            // update newVelocity here
        }
        
    }
}
