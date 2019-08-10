using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 500f;
    public float jumpheight = 600f;
    public bool jumpReady;
    public float torquespeed = 150f;
    float yForce;
    float xForce;
    float xTorque;
    public bool ftlleft = false;
    public bool ftlright = false;

    void Start()
    {

    }


    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.tag == "JumpReset" || collider.collider.tag == "Enemy")
        {
            jumpReady = true;
        }

    }

    void FixedUpdate()
    {
        if(rb.velocity.x > 12)
        {
            ftlright = true;
        } else
        {
            ftlright = false;
        }
        if (rb.velocity.x < -10)
        {
            ftlleft = true;
        }
        else
        {
            ftlleft = false;
        }
        float xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("w") && jumpReady || Input.GetKeyDown("space") && jumpReady)
        {
            rb.AddForce(new Vector2(0, jumpheight));
            jumpReady = false;
        }
        xForce = xInput * speed * Time.deltaTime;
        xTorque = xInput * torquespeed * Time.deltaTime;

        Vector2 force = new Vector2(xForce, 0);
        rb.AddForce(force);
        rb.AddTorque(-xTorque);
            
    }
}
