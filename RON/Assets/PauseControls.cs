using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControls : MonoBehaviour
{
	[SerializeField] private GameObject PauseScreen; 
	//[SerializeField] private GameObject Player; 
    [SerializeField] private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("Player"); 
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
    }
}
