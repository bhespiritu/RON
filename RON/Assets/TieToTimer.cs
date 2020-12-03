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

    public void LoadStage(int stage = 3)
    {
        timer.LoadStage(stage);
    }

    public void LoadNextStage()
    {
        timer.LoadNextStage();
    }

}
