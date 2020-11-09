using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    public Animator animator;
    public SpriteRenderer sprite;

    [HideInInspector]
    public EnemyInfo enemyInfo;

    public Vector2 waypoint;

    private float startTime;
    public float timeSince
    {
        get
        {
            return GameTimer.time - startTime;
        }
    }

    private void Start()
    {
        enemyInfo = GetComponent<EnemyInfo>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        currentState.StateUpdate(this);

        bool shouldTransition = true;

        if(currentState.requireCooldown)
        {
            shouldTransition = timeSince > currentState.cooldown;
        }

        if (shouldTransition)
        {
            State nextState = currentState.nextState(this);
            if (nextState != currentState)
            {
                transitionToState(nextState);
            }
        }
    }

    public void transitionToState(State s)
    {
        currentState.OnExit(this);
        currentState = s;
        s.OnEnter(this);
        startTime = GameTimer.time;
    }
    
}
