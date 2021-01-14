using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable : MonoBehaviour
{
    //private bool moving;
    private Rigidbody2D body;
    private Transform transform;
    private bool locked;
    private float timeWhenLocked;
    private Vector3 newVelocity;
    public GameObject indicatorArrow;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //moving = false;

        body = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
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

        if (locked && (Time.time - timeWhenLocked > 5)) // locks last 5 seconds
        {
            locked = false;
            body.isKinematic = false;
            Destroy(transform.GetChild(0).gameObject);
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

            // create arrow indicator

            Instantiate(indicatorArrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation, transform);
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

    public void ApplyMomentumNewMethod(float mousexpos, float mouseypos)
    {
        if (locked)
        {
            //print("touched");
            Debug.Log("xpos: " + mousexpos + " ypos: " + mouseypos);
            // update newVelocity here
            float xpos = body.position.x;
            float ypos = body.position.y;

            // calc the direction to apply
            float xdelta = xpos - mousexpos;
            float ydelta = ypos - mouseypos;

            
            if (xdelta > 0)
            {
                // apply from left to right
                newVelocity.x += 0.5f;
            }
            else
            {
                newVelocity.x -= 0.5f;
            }
            if (ydelta > 0)
            {
                // apply from botom to top
                newVelocity.y += 0.5f;
            }
            else
            {
                newVelocity.y -= 0.5f;
            }

            // and also change the direction and size of the arrow
            transform.GetChild(0).localScale = new Vector3(0.5f, Mathf.Sqrt(newVelocity.x * newVelocity.x + newVelocity.y + newVelocity.y), 0);
            Quaternion target = Quaternion.Euler(0, 0, Mathf.Atan(newVelocity.y / newVelocity.x) * Mathf.Rad2Deg + 100);
            transform.GetChild(0).rotation = target;


        }
    }

    public bool lockState()
    {
        return locked;
    }
}
