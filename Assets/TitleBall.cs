using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBall : MonoBehaviour
{
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector3(2.5f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
