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
        INTRO, TAUNT, SIDEATTACK, DRONESTRIKE, SHOOT
    }

    FinalBossState currentState = FinalBossState.INTRO;
    FinalBossState nextState = FinalBossState.INTRO;

    private Collider2D col;
    private EnemyInfo info;
    public GameObject projectile;

    private float startStateTime = 0;
    public float timeSinceStart
    {
        get
        {
            return GameTimer.time - startStateTime;
        }
    }

    [Header("Intro Settings")]
    public float introDuration = 10;
    [Header("Shoot Settings")]
    public float shootDuration = 5;
    public float pulsePeriod = 2;
    public float shotPeriod = 1 / 3f;
    public float bulletSpeed = 10;
    private float timeShoot = 0;
    [Header("Side Attack Settings")]
    public float sideAttackDuration = 5;
    public float sidePulsePeriod = 4;
    public float sidePulseLength = 2;
    private float sidePulseY = 0;

    public void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        info = GetComponent<EnemyInfo>();
    }

    public void Update()
    {
        nextState = checkChange();
        if(nextState != currentState)
        {
            currentState = nextState;
            startStateTime = GameTimer.time;
        }
        StateUpdate();

    }

    public void StateUpdate()
    {
        switch (currentState)
        {
            case FinalBossState.INTRO:
                break;
            case FinalBossState.SHOOT:
                col.enabled = true;
                float pulseProgress = (timeSinceStart % pulsePeriod) / pulsePeriod;
            
                if(pulseProgress < 0.5f)
                {
                    float timeSinceShoot = GameTimer.time - timeShoot;
                    if(timeSinceShoot > shotPeriod)
                    {
                        timeShoot = GameTimer.time + shotPeriod;
                        Vector2 targetPos = info.target.position;
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
                col.enabled = false;

                break;

        }
    }

    public FinalBossState checkChange()
    {
        switch(currentState)
        {
            case FinalBossState.INTRO:
                if(timeSinceStart > introDuration)
                {
                    return FinalBossState.SHOOT;
                }
                break;
            case FinalBossState.SHOOT:

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
