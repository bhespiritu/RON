using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2[] targets;
    public float travelTime, endTime;
    private int cTar, pTar;
    private bool travelling;
    private float cTime;
    public bool warehouse = false;
    public bool lobby = false;
    public float playerMove = 0f;
    void Start()
    {
        cTar = 0; //NOTE: the first position is the initial location of the platform
        pTar = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Platform moving: " + travelling + ", cTime = " + cTime + ", position " + transform.position);
        //Debug.Log("cTar " + cTar + " = " + targets[cTar] + ", pTar " + pTar + " = " + targets[pTar] );

        cTime += Time.deltaTime;
        
        if(!travelling){
            if(cTime == Time.deltaTime){
                //Debug.Log("cTar " + cTar + " = " + targets[cTar] + ", pTar " + pTar + " = " + targets[pTar] );
                pTar++;
                cTar++;
                if(cTar == targets.Length){
                    cTar = 0;
                }
                if(pTar == targets.Length){
                    pTar = 0;
                }
            }
            cTime += Time.deltaTime;
            if(cTime >= endTime){
                travelling = true;
                cTime = 0f;
            }
        }else{
            transform.position = Vector3.Lerp(new Vector3(targets[pTar].x, targets[pTar].y,0), new Vector3(targets[cTar].x, targets[cTar].y,0), (cTime/travelTime));
            if(cTime >= travelTime){
                travelling = false;
                cTime = 0f;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 14 && this.travelling && this.warehouse)
        {
            if (this.cTar == 1)
            {
                Debug.Log("moving right");
                Player.playerInstance.transform.position = new Vector2(Player.playerInstance.transform.position.x + this.playerMove, Player.playerInstance.transform.position.y);
            }
            if (this.cTar == 0)
            {
                Debug.Log("moving left collision stay");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.cTar == 0 && this.warehouse)
        {
           Debug.Log("moving left collision enter");
           Player.playerInstance.transform.position = new Vector2(Player.playerInstance.transform.position.x - this.playerMove, Player.playerInstance.transform.position.y);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (this.cTar == 0 && this.warehouse)
        {
            Debug.Log("moving left collision exit");
            Player.playerInstance.transform.position = new Vector2(Player.playerInstance.transform.position.x - this.playerMove, Player.playerInstance.transform.position.y);
        }
    }
}
