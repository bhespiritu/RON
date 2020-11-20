using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stage : MonoBehaviour
{
    public GameObject bossPF, bossReal, elevator, wMessage, qButton;
    private UnityEngine.UI.Text msg;
    private bool bAlive;
    private float tKill, sMsg = 5f, eMsg=12f;
    private int mStage;
    // Start is called before the first frame update
    void Start()
    {
        //bossReal = GameObject.FindGameObjectWithTag("Boss"); //Instantiate(bossPF, new Vector3(0,5,0), Quaternion.identity);
        bAlive = true;
        elevator.SetActive(false);
        wMessage.SetActive(false);
        qButton.SetActive(false);
        tKill = 0f;
        msg = wMessage.GetComponent<UnityEngine.UI.Text>();
        mStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(bAlive && bossReal.GetComponent<EnemyInfo>().health <= 0){
            elevator.SetActive(true);
            wMessage.SetActive(true);
            elevator.GetComponent<Elevator_Master>().setEFin();
            bAlive = false;
        }else if (!bAlive && mStage < 2){
            tKill += Time.deltaTime;
            if(tKill >= sMsg && mStage == 0){
                msg.fontSize = 50;
                msg.text = "Leave the game or take the elevator to continue your journey";
                qButton.SetActive(true);
                mStage = 1;
            }else if(tKill >= eMsg && mStage == 1){
                wMessage.SetActive(false);
                mStage = 2;
            }
        }
    }
}
