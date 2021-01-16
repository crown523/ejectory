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

        if(locked && (Time.time - timeWhenLocked < 5))
        {
            sprite.color = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.time, (6f - (Time.time - timeWhenLocked))/5 ));
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

            // if (xdelta > 0)
            // {
            //     // apply from left to right
            //     newVelocity.x += 0.5f;
            // }
            // else
            // {
            //     newVelocity.x -= 0.5f;
            // }
            // if (ydelta > 0)
            // {
            //     // apply from botom to top
            //     newVelocity.y += 0.5f;
            // }
            // else
            // {
            //     newVelocity.y -= 0.5f;
            // }

            // and also change the direction and size of the arrow
            transform.GetChild(0).localScale = new Vector3(0.5f, Mathf.Sqrt(newVelocity.x * newVelocity.x + newVelocity.y * newVelocity.y), 0);
            // do calculations to determine the position of the arrow (since it scales from center)

            // calculate rotation angle
            float rotAngle = Mathf.Atan(newVelocity.y / newVelocity.x) * Mathf.Rad2Deg + 90;
            // rotate the arrow
            Quaternion target = Quaternion.Euler(0, 0, rotAngle);
            transform.GetChild(0).rotation = target;

            //rotAngle = 0 - rotAngle; //idk man
            Debug.Log("rotangle: " + rotAngle);

            // based on which quadrant the arrow is pointing in
            // move the arrow to the top/bottom/left/right side of the box
            Vector3 startingArrowPos;
            // if (rotAngle >= 337.5 || rotAngle < 22.5)
            // {
            //     Debug.Log("top");
            //     startingArrowPos = new Vector3(xpos, ypos + GetComponent<Renderer>().bounds.extents.y, 0);
            // }
            // else if (rotAngle < 67.5)
            // {
            //     Debug.Log("topright");
            //     // topright
            //     startingArrowPos = new Vector3(xpos + GetComponent<Renderer>().bounds.extents.x, ypos + GetComponent<Renderer>().bounds.extents.y, 0);
            // }
            // else if (rotAngle < 112.5)
            // {
            //     Debug.Log("right");
            //     // right
            //     startingArrowPos = new Vector3(xpos + GetComponent<Renderer>().bounds.extents.x, ypos, 0);
            // }
            // else if (rotAngle < 157.5)
            // {
            //     Debug.Log("bottomright");
            //     // bottomright
            //     startingArrowPos = new Vector3(xpos + GetComponent<Renderer>().bounds.extents.x, ypos - GetComponent<Renderer>().bounds.extents.y, 0);
            // }
            // else if (rotAngle < 202.5)
            // {
            //     Debug.Log("bottom");
            //     // bottom
            //     startingArrowPos = new Vector3(xpos, ypos - GetComponent<Renderer>().bounds.extents.y, ypos);
            // }
            // else if (rotAngle < 247.5)
            // {
            //     Debug.Log("bottomleft");
            //     // bottomleft
            //     startingArrowPos = new Vector3(xpos - GetComponent<Renderer>().bounds.extents.x, ypos - GetComponent<Renderer>().bounds.extents.y, 0);
            // }
            // else if (rotAngle < 292.5)
            // {
            //     Debug.Log("left");
            //     // left
            //     startingArrowPos = new Vector3(xpos - GetComponent<Renderer>().bounds.extents.x, ypos, 0);
            // }
            // else
            // {
            //     Debug.Log("topleft");
            //     // topleft
            //     startingArrowPos = new Vector3(xpos - GetComponent<Renderer>().bounds.extents.x, ypos + GetComponent<Renderer>().bounds.extents.y, 0);
            // }


            // please someone come up with a better way to do this cuz my brain is fried
            if (newVelocity.x > newVelocity.y)
            {
                if (newVelocity.x > 0)
                {
                    Debug.Log("right");
                    arrowLoc = "right";
                    startingArrowPos = new Vector3(xpos + GetComponent<Renderer>().bounds.extents.x, ypos, 0);
                }
                else
                {
                    Debug.Log("left");
                    arrowLoc = "left";
                    startingArrowPos = new Vector3(xpos - GetComponent<Renderer>().bounds.extents.x, ypos, 0);
                }
            }
            else
            {
                if (newVelocity.y > 0)
                {
                    Debug.Log("top");
                    arrowLoc = "top";
                    startingArrowPos = new Vector3(xpos, ypos + GetComponent<Renderer>().bounds.extents.y, 0);
                }
                else
                {
                    Debug.Log("bottom");
                    arrowLoc = "bot";
                    startingArrowPos = new Vector3(xpos, ypos - GetComponent<Renderer>().bounds.extents.y, ypos);
                }
            }
            

            // based on the scale, adjust the position of the center
            // so that the end of the scaled arrow is located at startingArrowPos
            // at scale 1 the end of thearrow is 
            // indicatorArrow.GetComponent<Renderer>().bounds.extents.y units away from the center


            // doesn't really work
            // fml
            Vector3 adjustedArrowPos = new Vector3(0,0,0); //prevents error
            float xoffset = 5 * indicatorArrow.GetComponent<Renderer>().bounds.extents.x * transform.GetChild(0).localScale.y;
            float yoffset = 5 * indicatorArrow.GetComponent<Renderer>().bounds.extents.y * transform.GetChild(0).localScale.y;

            switch (arrowLoc)
            {   
                case "left":
                    adjustedArrowPos = startingArrowPos + new Vector3(-xoffset, 0, 0);
                    break;
                case "right":
                    adjustedArrowPos = startingArrowPos + new Vector3(xoffset, 0, 0);
                    break;
                case "top":
                    adjustedArrowPos = startingArrowPos + new Vector3(0, yoffset, 0);
                    break;
                case "bot":
                    adjustedArrowPos = startingArrowPos + new Vector3(0, -yoffset, 0);
                    break;
            }

            Debug.Log(adjustedArrowPos);
            transform.GetChild(0).position = adjustedArrowPos;
        }
    }

    public bool lockState()
    {
        return locked;
    }
}
