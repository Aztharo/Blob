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


    public void OnCollisionEnter2D()
    {
        jumpReady = true;

    }

    void FixedUpdate()
    {
        if(rb.velocity.x > 7)
        {
            ftlright = true;
        } else
        {
            ftlright = false;
        }
        if (rb.velocity.x < -7)
        {
            ftlleft = true;
        }
        else
        {
            ftlleft = false;
        }
        float xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("w") && jumpReady)
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
