using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_Reveal : MonoBehaviour
{

    public GameObject fog;
    GameObject player;
    public float oDist = 5f;
    bool active;
    public bool yCares;
    public string fName;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            float dist;
            if(yCares){
                dist = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)));
            }else{
                dist = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.transform.position.x, 0)));
            }
            //float dist = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(player.transform.position.x, 0)));
            //Debug.Log("Fog checker " + fName + ", dist " + dist);
            if(dist < oDist){
                fog.SetActive(false);
                //Debug.Log("Removing Fog");
                active = false;
            }
        }
    }
}
