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

        if (Time.time - timeWhenLocked > 5) // locks last 5 seconds
        {
            locked = false;
            body.isKinematic = false;
            //body.constraints = RigidbodyConstraints2D.None;
            body.velocity = newVelocity;
            //body.velocity = new Vector3(2, 2, 0); // for debug
        }

        // if (locked)
        // {
        //     body.velocity = new Vector3(0,0,0);
        // }
        //Debug.Log(body.velocity);

    }

    public void Lock()
    {
        if (!locked)
        {
            locked = true;
            timeWhenLocked = Time.time;
            print("locked");
            body.velocity = new Vector3(0,0,0); // kill movement
            //body.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            newVelocity = new Vector3(0,0,0);
            body.isKinematic = true;
        }
        
    }

    public void ApplyMomentum(float xaxis, float yaxis)
    {
        if (locked)
        {
            print("touched");
            Debug.Log("xaxis: " + xaxis + " yaxis: " + yaxis);
            // update newVelocity here
            newVelocity.x += xaxis * 10;
            newVelocity.y += yaxis * 10;
        }
        
    }
}
