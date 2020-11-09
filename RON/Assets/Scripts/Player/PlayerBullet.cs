using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 10;
    public GameObject dust;

    public void Start()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
        Destroy(gameObject, 5);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        Vector2 pos = collision.contacts[0].point;
        var dustEffect = Instantiate(dust, pos, Quaternion.identity);
        dustEffect.transform.up = collision.contacts[0].normal;
        Destroy(dustEffect, 1);

        if (collision.collider != null)
        {
            if (collision.collider.tag == "Enemy")
            {
                collision.collider.GetComponent<EnemyInfo>().Hurt(damage);
            }
        }


    }
}
