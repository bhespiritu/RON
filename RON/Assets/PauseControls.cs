using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControls : MonoBehaviour
{
	[SerializeField] private GameObject PauseScreen; 
	[SerializeField] private Player p; 
	[SerializeField] public Text t; 
    [SerializeField] private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("player").GetComponent<Player>(); 
        t = GameObject.Find("StatsText").GetComponent<Text>(); 
        t.text = "Your Stats: Health = " + p.health + ", Money = " + p.money + ", Speed = " + p.speed;
        
    }

    // Update is called once per frame
    void Update()
    {
    	 if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused; 
        
        	if(isPaused){
            	Pause(); 
        	}else{
          	  	DeactivatePause(); 
        }
    }
        
    }
    public void Resume(){
        DeactivatePause(); 
    }
    public void Pause(){ 
        ActivatePause(); 
    }
    public void DeactivatePause(){
        Time.timeScale = 1f; 
       // Player.SetActive(true);
        PauseScreen.SetActive(false); 
    }
    public void ActivatePause(){
        Time.timeScale = 0f; 
        //Player.SetActive(false); 
        PauseScreen.SetActive(true); 
        Debug.Log("I get here"); 
        t.text = "Your Stats:\nHealth= " + p.health + "/" +p.maxHealth+ ",   Money= $" + p.money + ",   Speed= " + p.speed + ",   CritChance= " + p.critChance;
        //PauseScreen.SetActive(true); 
    }
}
