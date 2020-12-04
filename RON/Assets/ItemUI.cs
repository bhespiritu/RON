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
	public float timerA;
    public float timerS;
	public float runsA; 
    public float runsS; 

    // Start is called before the first frame update
    void Start()
    {
        //trans = GetComponent<CanvasGroup>();
 		//trans.a = a value;
 		activeOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
		secondaryOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
		runsA = 0; 
        runsS = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void LeftHit(){
    	activeOverlay.GetComponent<Image>().color = new Color(142,142,142,213);
    	StartCoroutine(NoWait()); 
    }
    public void LeftHitC(float timer){
        activeOverlay.GetComponent<Image>().color = new Color(142,142,142,213);
        this.timerA = timerA; 
        activeOverlay.GetComponent<Image>().fillAmount = 1; 
        StartCoroutine(ActuallyWaitActive());
        fillTotal = 1; 
        runsA = 0;
    }
    public void RightHit(float timer){
    	secondaryOverlay.GetComponent<Image>().color = new Color(142,142,142,213); 
        this.timerS = timerS; 
		secondaryOverlay.GetComponent<Image>().fillAmount = 1; 
        StartCoroutine(ActuallyWait());
        fillTotal = 1; 
        runsS = 0;
    }
    IEnumerator NoWait(){
		yield return new WaitForSeconds(.25f);
    	activeOverlay.GetComponent<Image>().color = new Color(142,142,142,0);
    }
    IEnumerator ActuallyWait(){
    	runsS++; 
        //yield on a new YieldInstruction that waits
        yield return new WaitForSeconds((float)timerS/10);
        fillTotal -= .1f;
        secondaryOverlay.GetComponent<Image>().fillAmount = fillTotal;  
        if(runsS < 10 && fillTotal>0)
        	StartCoroutine(ActuallyWait()); 
    }
    IEnumerator ActuallyWaitActive(){
        runsA++; 
        //yield on a new YieldInstruction that waits
        yield return new WaitForSeconds((float)timerA/10);
        fillTotal -= .1f;
        activeOverlay.GetComponent<Image>().fillAmount = fillTotal;  
        if(runsA < 10 && fillTotal>0)
            StartCoroutine(ActuallyWait()); 
    }
}
