using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    Rigidbody2D ballRb2d;
    GameObject ball;
    public KeyCode ballLaunch = KeyCode.Space;
    public KeyCode restart = KeyCode.Return;    
    public FixedJoint2D fj2d;
    public bool launched = false;
    public GameObject powerupPaddle, powerupBall;
    public bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
        ballRb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
       if (!launched)
        {
            shoot();
        }
        if(Input.GetKey(restart) && end)
        {
            
        }
        
    }
    void shoot()
    {
        
        if (Input.GetKey(ballLaunch))
        {
            launched = true;
            fj2d.enabled = false;
            ballRb2d.velocity = new Vector2(5, 5);
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
       
        if(collision2D.gameObject.tag == "brick")
        {
            Destroy(collision2D.gameObject);
            float position = Random.Range(0, 10);
            if(position > 5)
            {
                Instantiate(powerupBall, collision2D.transform.position, Quaternion.identity);
            }
            else 
            {
                Instantiate(powerupPaddle, collision2D.transform.position, Quaternion.identity);
            }
            
        }
        if(collision2D.gameObject.tag == "Bottom")
        {     
               ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
               end = true;     
        }
    }

}
