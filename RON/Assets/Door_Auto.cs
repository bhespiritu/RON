using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Auto : MonoBehaviour
{
    SpriteRenderer dSprite;
    public GameObject player, door;
    public float oDist = 5f;
    bool closed;
    // Start is called before the first frame update
    void Start()
    {
        dSprite = GetComponent<SpriteRenderer>();
        closed=true;
        dSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(closed){
            float dist = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)));
            if(dist < oDist){
                dSprite.enabled = true;
                door.SetActive(false);
            }
        }
        


    }
}
