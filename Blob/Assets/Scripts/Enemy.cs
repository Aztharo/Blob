using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float retDis;
    public float stopDis;
    public float bulletSpeed;

    private Transform player;
    public GameObject projectile;
    public GameObject shootpoint;
    public GameObject middle;
    public GameObject destroyEffect;
    public CameraShake CameraShake;

    private float timeBtwShots;
    public float startTimeBtwShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().ftlleft && collision.collider.name == "Player" || GameObject.Find("Player").GetComponent<PlayerMovement>().ftlright && collision.collider.name == "Player")
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            CameraShake.Shake(1f);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 difference = player.transform.position - shootpoint.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        middle.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Vector2.Distance(transform.position, player.position) > stopDis) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) > retDis && Vector2.Distance(transform.position, player.position) <stopDis) 
        {

        }
        else if(Vector2.Distance(transform.position, player.position) < retDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            
            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(projectile) as GameObject;
        b.transform.position = shootpoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}