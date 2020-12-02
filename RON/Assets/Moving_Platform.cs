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
}
