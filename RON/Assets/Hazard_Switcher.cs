using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Switcher : MonoBehaviour
{
    // Start is called before the first frame update
    float cTime;
    public float uTime, eTime;
    public Animator animator;
    bool exclamation;
    void Start()
    {
        cTime = 0;
        exclamation = true;
    }

    // Update is called once per frame
    void Update()
    {
        cTime += Time.deltaTime;
        if((exclamation && cTime >= eTime)||(!exclamation && cTime >= uTime)){
            cTime = 0;
            if(exclamation){
                animator.SetTrigger("E to U");
            }else{
                animator.SetTrigger("U to E");
            }
            exclamation = !exclamation;
        }
    }
}
