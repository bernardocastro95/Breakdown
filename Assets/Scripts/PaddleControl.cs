using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    GameObject paddle;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 25.0f;
    float boost = 10.0f;
    public float boundX = 11.4f;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindGameObjectWithTag("paddle");
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
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "powerupSpeed")
        {
            speed += boost;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "powerupPaddle")
        {
            
            paddle.transform.localScale = new Vector2(5.2f, 0.2f);
            boundX = 10.0f;
            Destroy(other.gameObject);       
        }
    }

}
