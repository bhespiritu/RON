using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
	[SerializeField] public Image activeOverlay; 
	[SerializeField] public Image secondaryOverlay; 
	public float fillTotal = 1;  
	//public float amt; 
	public float timer;
	public float runs; 

    // Start is called before the first frame update
    void Start()
    {
        //trans = GetComponent<CanvasGroup>();
 		//trans.a = a value;
 		activeOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
		secondaryOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
		runs = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void LeftHit(){
    	activeOverlay.GetComponent<Image>().color = new Color(142,142,142,213);
    	StartCoroutine(NoWait()); 
    }
    public void RightHit(float timer){
    	secondaryOverlay.GetComponent<Image>().color = new Color(142,142,142,213); 
        //this.amt = amt;
        this.timer = timer; 
		secondaryOverlay.GetComponent<Image>().fillAmount = 1; 
        StartCoroutine(ActuallyWait());
        fillTotal = 1; 
        runs = 0;
		//secondaryOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
       /* fillTotal = (float) amt/timer;
        secondaryOverlay.GetComponent<Image>().fillAmount = fillTotal;  
        if(fillTotal <= 0){
        	fillTotal = 1; 
        	secondaryOverlay.GetComponent<Image>().fillAmount = fillTotal;  
        }*/
    }
    IEnumerator NoWait(){
		yield return new WaitForSeconds(.25f);
    	activeOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
    }
    IEnumerator ActuallyWait(){
    	runs++; 
        //yield on a new YieldInstruction that waits
        yield return new WaitForSeconds((float)timer/10);
        fillTotal -= .1f;
        secondaryOverlay.GetComponent<Image>().fillAmount = fillTotal;  
        
        if(runs < 10 && fillTotal>0)
        	StartCoroutine(ActuallyWait()); 
    }
}
