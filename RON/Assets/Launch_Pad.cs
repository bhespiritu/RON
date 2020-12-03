using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch_Pad : MonoBehaviour
{
    GameObject player;
    public float Power=5f;
    Rigidbody2D pRB;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)));
        pRB.velocity = new Vector2(pRB.velocity.x, Mathf.Min(dist, 2f)*Power);
    }
}
