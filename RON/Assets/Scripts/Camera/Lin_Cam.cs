using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lin_Cam : MonoBehaviour
{
    public Vector2 sPos;
    public float spd, xTether;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(spd*Time.deltaTime, 0f, 0f);
        if(Mathf.Abs(transform.position.x - sPos.x) >=xTether){
            transform.position = new Vector3(sPos.x, sPos.y, transform.position.z);
        }
    }
}
