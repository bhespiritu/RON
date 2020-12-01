using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossUI : MonoBehaviour
{
    public static BossUI instance;

    public EnemyInfo trackedEnemy;
    public Elevator_Master elevator;

    public Slider healthBar;
    public Text TimerLabel;
    public Text TimerDisplay;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += HideOnLoad;
    }

    // Start is called before the first frame update
    void Start()
    {
        Elevator_Master.sChg += HandleElevatorChange;
    }

    private void OnDestroy()
    {
        Elevator_Master.sChg -= HandleElevatorChange;
    }

    public void HandleElevatorChange()
    {
        if(!elevator)
        {
            elevator = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Elevator_Master>();
        }
        if(elevator.st == Elevator_Master.eState.Event)
        {
            ShowUI(true);
        } 
    }

    public void HideOnLoad(Scene scene, LoadSceneMode mode)
    {
        HideUI();
    }

    public void ShowUI(bool withTimer)
    {
        
        healthBar.gameObject.SetActive(true);
        if (withTimer)
        {
            TimerDisplay.gameObject.SetActive(true);
            TimerLabel.gameObject.SetActive(true);
        }
        trackedEnemy = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyInfo>();
    }

    public void HideUI()
    {
        healthBar.gameObject.SetActive(false);
        TimerDisplay.gameObject.SetActive(false);
        TimerLabel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(trackedEnemy)
            healthBar.value = trackedEnemy.health / trackedEnemy.initialHealth;
        if (elevator)
        {
            float timeLeft = elevator.dur - (GameTimer.time - elevator.started);
            if (timeLeft < 0) timeLeft = 0;
            if(timeLeft != 0)
                TimerDisplay.text = timeLeft.ToString("F") + "s";
            else
                TimerDisplay.text = "Arrived!";
        }
    }
}
