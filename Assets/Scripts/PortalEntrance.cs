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
        if (orientation = "horizontal")
        {
            other.attachedRigidbody.velocity.x *= -1;
        }
        else
        {
            other.attachedRigidbody.velocity.y *= -1;
        }
        other.attachedRigidbody.position = portalExit.GetComponent<Transform>.position;
    }
}
