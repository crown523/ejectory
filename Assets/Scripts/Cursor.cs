using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 mousePosition;
    private Animator animator;
    public float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        if(Input.GetMouseButtonDown(1) && !animator.GetBool("hammerMode")) 
        // can we rename swap to isLockMode or something similar
        // so that its more clear which mode it's in
        {
            animator.SetBool("hammerMode", true);
        }
        else if(Input.GetMouseButtonDown(1) && animator.GetBool("hammerMode"))
        {
            animator.SetBool("hammerMode", false);
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

    }
}
