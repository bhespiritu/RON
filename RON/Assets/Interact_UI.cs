using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player, target, tip;
    private Elevator_Master.eState mode;
    private Elevator_Master eleCtrl;
    private bool shown;

    void Start()
    {
        //Debug.Log("start for interacting");
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Elevator");
        eleCtrl = target.GetComponent<Elevator_Master>(); 
        shown = false; 
        tip.SetActive(false);
        Elevator_Master.sChg += ElStateChg;
        //Debug.Log("Finish for item shop");
    }

    // Update is called once per frame
    void Update()
    {
        if(mode != Elevator_Master.eState.Event){
            //Debug.Log("Distance from player to elevator is " + Mathf.Abs(Vector3.Distance(player.transform.position,target.transform.position)));
            if(!shown && Mathf.Abs(Vector3.Distance(player.transform.position,target.transform.position))<10f){
                shown = true;
                tip.SetActive(true);
            }
            if(shown && Mathf.Abs(Vector3.Distance(player.transform.position,target.transform.position))>10f){
                shown = false;
                tip.SetActive(false);
            }
        }else if (shown){
            shown = false;
            tip.SetActive(false);
        }
    }

    void ElStateChg(){
        Debug.Log("Interact heard that EState Changed");
        mode = eleCtrl.st;
    }
}
