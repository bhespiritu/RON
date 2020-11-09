using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;

    public void Start()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
        Destroy(gameObject, 5);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.collider != null)
        {
            if(collision.collider.tag == "Player")
            {
                collision.collider.GetComponent<Player>().TakeDamage(damage);
            }
        }

        
    }
}
