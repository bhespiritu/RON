using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieToTimer : MonoBehaviour
{
    private GameTimer timer;
    public void Awake()
    {
        timer = GameTimer._instance;
    }

    public void LoadMain()
    {
        timer.LoadMainScene();
    }

}
