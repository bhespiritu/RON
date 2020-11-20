using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Master : MonoBehaviour
{
    // Start is called before the first frame update
    private float started;
    public enum eState {Initial, Event, Finished};
    public eState st;

    public Rigidbody2D player;
    private float iDist = 2f, lAcc;
    public float dur = 30f, lWait = 2f;
    private bool leaving;
    private SpriteRenderer eSprite;
    public Sprite Init, Wait, Fin;

    public GameObject sObj;
    public Spawner_Master sCtrl;
    public delegate void elEvent();
    public static event elEvent sChg;
    public int nextStage;
    
    void Start()
    {
        st = eState.Initial;
        eSprite = GetComponent<SpriteRenderer>();
        eSprite.sprite = Init;
        sCtrl = sObj.GetComponent<Spawner_Master>();
        player = Player.playerInstance.GetComponent<Rigidbody2D>();
        leaving = false;
        lAcc = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("State is " + st + ", E pressed: " + Input.GetKey(KeyCode.E) + ", Distance is " + Mathf.Abs(Vector2.Distance(new Vector2(player.transform.position.x,player.transform.position.y), new Vector2(transform.position.x, transform.position.y))) + "\nPlayer pos is " + player.transform.position + ", Elevator pos is " + transform.position);
        if(st == eState.Finished && !leaving && Input.GetKey(KeyCode.E)){
            leaving = true;
        }
        if(leaving){
            lAcc+=Time.deltaTime;
            if(lAcc >= lWait){
                Leave();
            }
        }else{
            //Debug.Log("State is " + st + "E pressed: " + Input.GetKey(KeyCode.E) + "Distance is " + Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)));
            if(st == eState.Initial && Input.GetKey(KeyCode.E) && Mathf.Abs(Vector2.Distance(new Vector2(player.transform.position.x,player.transform.position.y), new Vector2(transform.position.x, transform.position.y))) < iDist){
                st = eState.Event;
                //sCtrl.ElevatorSignal();
                sChg();
                started = GameTimer.time;
                eSprite.sprite = Wait;
                sCtrl.SpawnMiniboss();
            }

            //if(st==eState.Event){Debug.Log("Time Elapsed since elevator: " + (GameTimer.time - started) + ", dur = " + dur);}

            if(st == eState.Event && (GameTimer.time - started) > dur){
                st = eState.Finished;
                //sCtrl.ElevatorSignal();
                sChg();
                eSprite.sprite = Fin;
                //leaving = true;
            }
        }
    }

    void Leave(){
        //put code to switch to item shop here
        if(leaving){
            leaving = false;
            GameTimer._instance.LoadItemShop(nextStage);
        }
        
    }

    public void setEFin(){
        st = eState.Finished;
        sChg();
        eSprite.sprite = Fin;
    }
}
