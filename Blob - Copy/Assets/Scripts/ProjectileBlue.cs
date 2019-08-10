using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBlue : MonoBehaviour
{


    public GameObject destroyEffect;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Player")
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}