using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public UnityEngine.UI.Text TimeUI;
    // Start is called before the first frame update
    private int hours, mins, sec;
    private float pTime;
    private string cTime;
    void Start()
    {
        hours = 0;
        mins = 0;
        sec = Mathf.FloorToInt(GameTimer.time);
        pTime = GameTimer.time;
    }

    // Update is called once per frame
    void Update()
    {
        hours = 0;
        mins = 0;
        sec = 0;
        pTime = GameTimer.time;
        pTime = Mathf.FloorToInt(pTime);
        //Debug.Log("pTime is " + pTime);
        while(pTime > 3600){
            pTime -= 3600;
            hours++;
        }
        while(pTime > 60){
            pTime -= 60;
            mins++;
        }
        sec = Mathf.FloorToInt(pTime);

        cTime = string.Format("{0}:{1:00}:{2:00}", hours, mins, sec);
        //Debug.Log("Parts are: hours " + hours + ", minutes " + mins + ", seconds " + sec);
        //Debug.Log("cTime is " + cTime);
        
        TimeUI.text = cTime;
    }
}
