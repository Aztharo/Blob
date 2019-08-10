using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRed : MonoBehaviour
{


    public GameObject destroyEffect;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Enemy")
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