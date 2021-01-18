using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockable : MonoBehaviour
{
    //private bool moving;
    private Rigidbody2D body;
    private Transform transform;
    private bool locked;
    private float timeWhenLocked;
    private Vector3 newVelocity;
    public GameObject indicatorArrow;
    private string arrowLoc;

    private SpriteRenderer sprite;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;

        body = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        body.velocity = new Vector3(0.0f, speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (locked && (Time.time - timeWhenLocked > 5)) // locks last 5 seconds
        {
            locked = false;
            body.isKinematic = false;
            Destroy(transform.GetChild(0).gameObject);
            //body.constraints = RigidbodyConstraints2D.None;
            body.velocity = newVelocity;
            //body.velocity = new Vector3(2, 2, 0); // for debug
        }

        if(locked && (Time.time - timeWhenLocked < 5))
        {
            sprite.color = Color.Lerp(Color.white, new Color(0.76f, 0.67f, 0f, 1f), Mathf.PingPong(Time.time, (6f - (Time.time - timeWhenLocked))/5) );
        }
        else
        {
            sprite.color = Color.white;
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

            //change sprite color
            sprite.color = Color.yellow;

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

    public void ApplyMomentumNewMethod(float hammerxpos, float hammerypos)
    {
        if (locked)
        {
            

            //print("touched");
            Debug.Log("xpos: " + hammerxpos + " ypos: " + hammerypos);
            // update newVelocity here
            float xpos = body.position.x;
            float ypos = body.position.y;

            // calc the direction to apply
            float xdelta = xpos - hammerxpos;
            float ydelta = ypos - hammerypos;

            newVelocity.x += xdelta;
            newVelocity.y += ydelta;

            // and also change the direction and size of the arrow
            transform.GetChild(0).localScale = new Vector3(0.5f, Mathf.Sqrt(newVelocity.x * newVelocity.x + newVelocity.y * newVelocity.y), 0);
            // do calculations to determine the position of the arrow (since it scales from center)

            // calculate rotation angle
            float rotAngle;
            if(newVelocity.x >= 0 && newVelocity.y >= 0) //Quadrant 1
            {
                rotAngle = Mathf.Atan(newVelocity.y / newVelocity.x) * Mathf.Rad2Deg - 90f;
            }
            else if (newVelocity.x < 0 && newVelocity.y >= 0) //Quadrant 2
            {
                rotAngle = Mathf.Atan(newVelocity.y / newVelocity.x) * Mathf.Rad2Deg + 90f;
            }
            else if (newVelocity.x < 0 && newVelocity.y < 0) //Quadrant 3
            {
                rotAngle = Mathf.Atan(newVelocity.y / newVelocity.x) * Mathf.Rad2Deg + 90f;
            }
            else
            {
                rotAngle = Mathf.Atan(newVelocity.y / newVelocity.x) * Mathf.Rad2Deg - 90f;
            }
    
            
            // rotate the arrow
            Quaternion target = Quaternion.Euler(0, 0, rotAngle);
            transform.GetChild(0).rotation = target;

            Debug.Log("rotangle: " + rotAngle);
        }
    }

    public bool lockState()
    {
        return locked;
    }
}
