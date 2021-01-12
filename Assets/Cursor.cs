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

        if(Input.GetMouseButtonDown(1) && !animator.GetBool("swap"))
        {
            animator.SetBool("swap", true);
        }
        else if(Input.GetMouseButtonDown(0) && animator.GetBool("swap"))
        {
            animator.SetBool("swap", false);
        }

        //transform.position = Input.mousePosition;
        //print(Input.mousePosition);
    }
}
