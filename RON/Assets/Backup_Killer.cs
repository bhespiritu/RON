using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backup_Killer : MonoBehaviour
{
    GameObject player;
    Player playerInf;
    public float minHt;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInf = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < minHt){
            playerInf.health = 0;
        }
    }
}
