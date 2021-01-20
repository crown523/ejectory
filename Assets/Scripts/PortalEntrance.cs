using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntrance : MonoBehaviour
{

    public GameObject portalExit;
    public string orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (orientation == "horizontal")
        {
            other.attachedRigidbody.velocity -= new Vector2(2 * other.attachedRigidbody.velocity.x, 0);
        }
        else
        {
            other.attachedRigidbody.velocity -= new Vector2(0, 2 * other.attachedRigidbody.velocity.y);
        }
        other.attachedRigidbody.position = portalExit.GetComponent<Transform>().position;
    }
}
