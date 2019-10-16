using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 25.0f;
    public float boundX = 11.4f;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
       
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 vel = new Vector2();
        if(Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        rb2d.velocity = vel;

        var pos = transform.position;

        if(pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if(pos.x < -boundX)
        {
            pos.x = -boundX;
        }
        transform.position = pos;
    }

    
}
