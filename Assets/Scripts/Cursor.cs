using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 mousePosition;
    private Animator animator;
    public float moveSpeed = 0.1f;

    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //attempt to stop cursor follow when hammer mode cursor is inside a Lockable object
        if(animator.GetBool("hammerMode"))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == null)
            {
                mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
            else
            {
                Lockable objScript = hit.collider.gameObject.GetComponent<Lockable>();

                if (!objScript || !objScript.lockState())
                {
                    mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                }
            }
        }
        else
        {
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        

        //switch cursor modes with right click
        if(Input.GetMouseButtonDown(1) && !animator.GetBool("hammerMode")) 
        {
            animator.SetBool("hammerMode", true);
            collider.enabled = true;
        }
        else if(Input.GetMouseButtonDown(1) && animator.GetBool("hammerMode"))
        {
            animator.SetBool("hammerMode", false);
            collider.enabled = false;
        }

        //transform.position = Input.mousePosition;
        //print(Input.mousePosition);

        // handle locking
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("hammerMode")) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) 
            {
                Debug.Log(hit.collider.gameObject.name);
                // if we clicked a lockable object
                if (hit.collider.gameObject.GetComponent<Lockable>())
                {
                    // get ref to the script
                    Lockable objScript = hit.collider.gameObject.GetComponent<Lockable>();
                    // delegate behavior to the object
                    objScript.Lock();
                }
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }
        //Debug.Log(Input.GetAxis("Mouse X") + " " + Input.GetAxis("Mouse Y"));

        // handle momentum application
        if (Input.GetMouseButtonDown(0) && animator.GetBool("hammerMode"))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) 
            {
                //handle momentum application
                if (hit.collider.gameObject.GetComponent<Lockable>())
                {
                    Lockable objScript = hit.collider.gameObject.GetComponent<Lockable>();
                    objScript.ApplyMomentumNewMethod(mousePos.x, mousePos.y);
                }
            }
        }
    }

    // smack-hammer-into-object method

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     print("hi");
    //     //old momentum application. kept in case its fundamentals are needed later
    //     /*
    //     if (animator.GetBool("hammerMode"))
    //     {
            
            
    //         Debug.Log(other.gameObject);
    //         //handle momentum application
    //         if (other.gameObject.GetComponent<Lockable>())
    //         {
    //             Lockable objScript = other.gameObject.GetComponent<Lockable>();
    //             objScript.ApplyMomentum(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    //         }
            
    //     }
    //     */

    //     //if the other collider is not Lockable, pass through it without 
    //     //affecting the momentum of the other object
    //     Lockable objScript = other.gameObject.GetComponent<Lockable>();

    //     if(animator.GetBool("hammerMode") && objScript && objScript.lockState())
    //     {
    //         //apply momentum
    //         objScript.ApplyMomentum(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    //     }
        

    // }

}
