using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
	[SerializeField] private GameObject PauseScreen; 
	[SerializeField] private Player p; 
	[SerializeField] public Text t; 
    [SerializeField] public static bool isPaused;
    public static bool sceneChange; 
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = false; 
        p = GameObject.Find("player").GetComponent<Player>(); 
        t = GameObject.Find("StatsText").GetComponent<Text>(); 
        t.text = "Your Stats: Health = " + (int)p.health + ", Money = " + p.money + ", Speed = " + p.speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneChange){
            sceneChange = false; 
            p = GameObject.Find("player").GetComponent<Player>(); 
            t = GameObject.Find("StatsText").GetComponent<Text>(); 
        }
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
    public void ToMain(){
        DeactivatePause(); 
        Destroy(Player.playerInstance);
        sceneChange = true; 
    	SceneManager.LoadScene(0);
    }
    public void DeactivatePause(){
        Time.timeScale = 1f; 
        PauseScreen.SetActive(false); 
    }
    public void ActivatePause(){
        Time.timeScale = 0f; 
        PauseScreen.SetActive(true); 
        t.text = "Your Stats:\nHealth= " + (int)p.health + "/" +p.maxHealth+ ",   Money= $" + p.money + ",   Speed= " + p.speed + ",   CritChance= " + p.critChance;
    }
}
