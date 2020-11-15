using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonBehavior : MonoBehaviour
{
	//public static SceneLoader singleton;
    // Start is called before the first frame update
 
    // Start is called before the first frame update
    void Start()
    {
        //Ensure only one instance of scene loader exists at a time.
        // This allows you to call functions in this script without needing to find a reference to it.
       /* if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);*/ // Allows this GameObject to persist through scene changes
    }
    void Update(){
       
    }

    public void MainMenu()
    {
        // Your code here
        SceneManager.LoadScene(0);
    }
    public void Tutorial(){
        SceneManager.LoadScene(1); 
    }
    public void Play()
    {
        // Your code here
        SceneManager.LoadScene(2);
    }
    public void Quit(){
    	Application.Quit(); 
    } 
    
}
