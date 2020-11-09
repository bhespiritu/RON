using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target; // What the camera should follow
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;
    void Start(){
    	target = GameObject.Find("player").transform;
    }
    //Called once every frame.
    private void Update()
    {
        if (target == null) return;

        // YOUR CODE HERE
        //Used Vector3.SmoothDamp: https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
        //Vector3 targetPosition = target.position;
      	Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
