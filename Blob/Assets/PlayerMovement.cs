using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float jumpheight = 500f;
    public bool jumpReady;
    void Start()
    {

    }

    public void OnCollisionEnter2D()
    {      
            jumpReady = true;

    }

    void FixedUpdate()
    {
        
        if (Input.GetKeyDown("w") && jumpReady)
        {
            rb.AddForce(new Vector2(0, jumpheight));
            jumpReady = false;

        }
        if (Input.GetKey("a"))
        {
            transform.position = transform.position + new Vector3(-speed, 0) * Time.deltaTime;

        }
        if (Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(speed, 0) * Time.deltaTime;

        }

    }
}