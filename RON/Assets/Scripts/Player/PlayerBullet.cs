using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 10;
    public GameObject dust;
    public string effect = "";
    public float maxBounces = 0;
    private Rigidbody2D rb;
    private Vector2 oldVel;

    public enum BulletType
    {
        ONE_OFF, REFLECT, BOUNCE
    }
    public BulletType type;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.right = rb.velocity;
        Destroy(gameObject, 5);
    }

    public void FixedUpdate()
    {
        oldVel = rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(maxBounces <= 0)
            Destroy(gameObject);
        else
        {
            switch(type)
            {
                case BulletType.ONE_OFF: Destroy(gameObject); break;
                case BulletType.REFLECT:
                    const int layerMask = 0b10100000000;// only reflect off of ground, not enemies.
                    int layerCheck = (1 << collision.collider.gameObject.layer) & layerMask;
                    if(layerCheck != 0)
                    {
                        Vector2 vel = oldVel;
                        rb.velocity = Vector2.Reflect(vel, collision.GetContact(0).normal);
                        transform.position = collision.GetContact(0).point;
                        transform.right = rb.velocity;
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
            maxBounces -= 1;
        }
        
        Vector2 pos = collision.contacts[0].point;
        var dustEffect = Instantiate(dust, pos, Quaternion.identity);
        dustEffect.transform.up = collision.contacts[0].normal;
        Destroy(dustEffect, 1);

        if (collision.collider != null)
        {
            if (collision.collider.tag == "Enemy")
            {
                collision.collider.GetComponent<EnemyInfo>().Hurt(damage);
                Destroy(gameObject);
                if (this.effect.Equals("slow"))
                {
                    collision.collider.GetComponent<EnemyInfo>().moveSpeed *= 0.99f;
                }
            }
        }


    }
}
