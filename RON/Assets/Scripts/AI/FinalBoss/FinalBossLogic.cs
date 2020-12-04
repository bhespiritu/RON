using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class FinalBossLogic : MonoBehaviour
{
    public enum FinalBossState
    {
        INTRO, TAUNT, SIDEATTACK, DRONESTRIKE, SHOOT, DEATH
    }

    public FinalBossState currentState = FinalBossState.INTRO;
    FinalBossState nextState = FinalBossState.INTRO;

    private Collider2D col;
    private EnemyInfo info;
    private Rigidbody2D rb;
    

    private float startStateTime = 0;
    public float timeSinceStart
    {
        get
        {
            return GameTimer.time - startStateTime;
        }
    }
    public bool doneEntry = false;

    [Header("Intro Settings")]
    public float introDuration = 10;
    [Header("Shoot Settings")]
    public float shootDuration = 5;
    public float pulsePeriod = 2;
    public float shotPeriod = 1 / 3f;
    public float bulletSpeed = 10;
    private float timeShoot = 0;
    public GameObject projectile;
    [Header("Side Attack Settings")]
    public float sideAttackDuration = 5;
    public float sidePulsePeriod = 4;
    public float sidePulseMinY = 0;
    public float sidePulseMaxY = 0;
    public GameObject sidePulse;
    private bool hasSidePulsed = false;
    [Header("Drone Strike Settings")]
    public float droneStrikeDuration = 5;
    public float droneStrikePeriod = 4;
    public float droneStrikeMinX = -1;
    public float droneStrikeMaxX = 1;
    public GameObject droneStrike;
    public bool hasDroneShot = false;
    [Header("Movement Settings")]
    public Transform[] spawnPoints;
    public float maxMovementRange = 17;
    [Header("Effect Prefabs")]
    public GameObject impactEffect;
    public Sprite talkIcon;

    private Player player;

    public void Start()
    {
        nextState = currentState;
        col = GetComponent<Collider2D>();
        col.enabled = false;
        info = GetComponent<EnemyInfo>();
        spawnPoints = GameObject.Find("BossSpawnPoints").GetComponentsInChildren<Transform>();
        rb = GetComponent<Rigidbody2D>();
        player = Player.playerInstance;
        BossUI.instance.trackedEnemy = info;
        BossUI.instance.ShowUI(false);
        
    }

    public void Update()
    {
        nextState = checkChange();
        if(nextState != currentState)
        {
            currentState = nextState;
            startStateTime = GameTimer.time;
            doneEntry = false;
            transform.position = spawnPoints[(int)Random.Range(0,spawnPoints.Length)].position;
        }
        StateUpdate();

    }

    private Vector2 targetPos;

    public void StateUpdate()
    {
        if(transform.position.x > maxMovementRange)
        {
            Vector3 newPos = transform.position;
            newPos.x = maxMovementRange;
            transform.position = newPos;
        } 
        if(transform.position.x < -maxMovementRange)
        {
            Vector3 newPos = transform.position;
            newPos.x = -maxMovementRange;
            transform.position = newPos;
        }

        if (info.health <= 0) currentState = FinalBossState.DEATH;

        float pulseProgress;
        switch (currentState)
        {
            case FinalBossState.INTRO:
                if(!doneEntry)
                {
                    PopupManager.instance.queuePopup(3, "Hans Crowe", "You are a fool to have come here.", talkIcon);
                    PopupManager.instance.queuePopup(3, "Hans Crowe", "Prepare to meet your demise", talkIcon);
                    doneEntry = true;
                }
                info.sprite.enabled = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                break;
            case FinalBossState.SHOOT:
                if (!doneEntry)
                {
                    doneEntry = true;
                    PopupManager.instance.queuePopup(3, "Elizabeth", "There he is! Get Him!", GameTimer._instance.girlTalkSprite); ;
                }
                col.enabled = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                info.sprite.enabled = true;
                pulseProgress = (timeSinceStart % pulsePeriod) / pulsePeriod;
            
                if(pulseProgress < 0.5f)
                {
                    float timeSinceShoot = GameTimer.time - timeShoot;
                    if(timeSinceShoot > shotPeriod)
                    {
                        timeShoot = GameTimer.time + shotPeriod;
                        if(!this.player.invisible)
                            targetPos = info.target.position;
                        Vector2 diff = targetPos - (Vector2)transform.position;
                        var bullet = Instantiate(projectile, transform.position, Quaternion.identity);
                        bullet.transform.localScale = Vector3.one * 0.75f;
                        bullet.GetComponent<Rigidbody2D>().velocity = diff.normalized*bulletSpeed;
                        bullet.GetComponent<Projectile>().damage = info.attackDamage;
                    } 
                }
                else
                {
                    timeShoot = GameTimer.time;
                }
                break;
            case FinalBossState.SIDEATTACK:
                if (!doneEntry)
                {
                    doneEntry = true;
                    PopupManager.instance.queuePopup(3, "Hans Crowe", "Call In The Lasers!", talkIcon);
                }
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                col.enabled = false;
                info.sprite.enabled = false;
                pulseProgress = (timeSinceStart % sidePulsePeriod) / sidePulsePeriod;

                if (pulseProgress < 0.5)
                {
                    if(!hasSidePulsed)
                    {
                        hasSidePulsed = true;
                        float targetY = (int)Random.Range(sidePulseMinY, sidePulseMaxY);
                        var pulse = Instantiate(sidePulse, Vector2.up * targetY, Quaternion.identity);
                    }
                }
                else hasSidePulsed = false;
                break;
            case FinalBossState.DRONESTRIKE:
                if (!doneEntry)
                {
                    doneEntry = true;
                    PopupManager.instance.queuePopup(3, "Elizabeth", "Darn it! He flew off and called a drone strike! Watch Out!", GameTimer._instance.girlTalkSprite); ;
                }
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                col.enabled = false;
                info.sprite.enabled = false;
                pulseProgress = (timeSinceStart % droneStrikePeriod) / droneStrikePeriod;

                if (pulseProgress < 0.5)
                {
                    if (!hasDroneShot)
                    {
                        hasDroneShot = true;
                        float targetX = (int)Random.Range(droneStrikeMinX, droneStrikeMaxX);
                        Vector2 spawnPos = Vector2.right * targetX;
                        spawnPos += Vector2.one * 50;
                        var strike = Instantiate(droneStrike, spawnPos, Quaternion.identity);
                    }
                }
                else hasDroneShot = false;
                break;
        }
        if(!doneEntry)
            doneEntry = true;
    }


    public FinalBossState checkChange()
    {
        float choice;
        switch (currentState)
        {
            case FinalBossState.INTRO:
                if(timeSinceStart > introDuration)
                {
                    return FinalBossState.SHOOT;
                }
                break;
            case FinalBossState.SHOOT:
                if (timeSinceStart > shootDuration)
                {
                    choice = Random.value;
                    if(choice < 0.5f)
                    {
                        return FinalBossState.DRONESTRIKE;
                    }
                    return FinalBossState.SIDEATTACK;
                }
                break;
            case FinalBossState.SIDEATTACK:
                if (timeSinceStart > sideAttackDuration)
                {
                    choice = Random.value;
                    if (choice < 0.25f)
                    {
                        return FinalBossState.DRONESTRIKE;
                    }
                    return FinalBossState.SHOOT;
                }
                break;
            case FinalBossState.DRONESTRIKE:
                if (timeSinceStart > droneStrikeDuration)
                {
                    choice = Random.value;
                    if (choice < 0.25f)
                    {
                        return FinalBossState.SIDEATTACK;
                    }
                    return FinalBossState.SHOOT;
                }
                break;
        }
        return currentState;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, System.Enum.GetName(typeof(FinalBossState), currentState));
    }
#endif

}
