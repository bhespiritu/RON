using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{

    private float muzzleProgress = 0;
    private float muzzleTime = 0;
    public float muzzleDuration = 0.25f;
    public float shotDistance = 10;
    public GameObject flash;
    public GameObject proj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Replay()
    {
        muzzleTime = Time.time;
        flash.SetActive(true);
        if(proj)
            proj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (Time.time - muzzleTime) / muzzleDuration;
        if (progress > 1)
        {
            flash.SetActive(false);
            if(proj)
                proj.SetActive(false);
        } else
        {
            if(proj)
                proj.transform.localPosition = Vector2.right * progress * shotDistance;
        }
    }
}
