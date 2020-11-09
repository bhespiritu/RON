using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashUpdater : MonoBehaviour
{
    public UnityEngine.UI.Text CashUI;
    public string baseMStr = "$";
    public GameObject player;
    private int pCash;
    // Start is called before the first frame update
    void Start()
    {
        CashUI = GetComponent<UnityEngine.UI.Text>();
        pCash = 0;
        Player.mChange += uCsh;
        uCsh(Player.playerInstance.money);
    }

    void OnDestroy()
    {
        Player.mChange -= uCsh;
    }

    // Update is called once per frame
    void uCsh(float f){
        CashUI = GetComponent<UnityEngine.UI.Text>();
        CashUI.text = baseMStr + Mathf.FloorToInt(f);
    }
}
