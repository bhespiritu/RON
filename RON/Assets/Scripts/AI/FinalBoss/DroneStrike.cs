using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStrike : MonoBehaviour
{
    public float damage = 10;
    public float radius = 1;
    public Vector2 initVel = -Vector2.one;
    public LayerMask layerMask = 1 << 14;
    public GameObject explosionEffect;

    public void Start()
    {
        GetComponent<Rigidbody2D>().velocity = initVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Collider2D[] hitCol = new Collider2D[1];
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = layerMask;
        filter.useLayerMask = true;
        var hit = Physics2D.OverlapCircle(transform.position,radius,filter,hitCol);
        Debug.Log(hit);
        if(hit > 0)
        {
            hitCol[0].GetComponent<Player>().TakeDamage(damage);            
        }
    }
}
