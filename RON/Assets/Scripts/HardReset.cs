using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Player.playerInstance != null)
            Destroy(Player.playerInstance.gameObject);
        if (GameTimer._instance != null)
            Destroy(GameTimer._instance.gameObject);
        if(BossUI.instance != null)
            Destroy(BossUI.instance.gameObject);
    }
}
