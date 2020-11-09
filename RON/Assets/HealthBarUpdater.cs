using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUpdater : MonoBehaviour
{
    public UnityEngine.UI.Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        Player.hChange += uBar;
    }

    void uBar(float hPer){
        healthBar.value = hPer;
    }    


}
