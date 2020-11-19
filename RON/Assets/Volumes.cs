using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumes : MonoBehaviour
{
	//Uncomment when there is soundtrack 
	/*public AudioSource AudioSource;  
	private float vol = 0f; */
    // Start is called before the first frame update
    void Start()
    {
        /*AudioSource = GetComponent<AudioSource>(); 
        AudioSource.Play(); */
    }

    // Update is called once per frame
    void Update()
    {
        //AudioSource.volume = vol; 
    }
    public void newVol(float volume){
    	//vol = volume; 

    }
}
