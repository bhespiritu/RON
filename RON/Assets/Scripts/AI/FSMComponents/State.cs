using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Action enterAction, exitAction;
    public Transition[] transitions;

    public float cooldown = 0;
    public bool requireCooldown = false;

    

    public void StateUpdate(StateMachine controller)
    {
        foreach (Action action in actions)
        {
            action.Act(controller);
        }
    }

    public State nextState(StateMachine controller)
    {
        float choice = Random.value;
        State nextState = this;
        foreach(Transition trans in transitions)
        {
            if (trans.canTransition(controller))
            {
                choice -= trans.weight;
                nextState = trans.toState;
                if(choice <= 0)
                {
                    return trans.toState;
                }
            }
        }
        return nextState;
    }

    public void OnEnter(StateMachine controller) => enterAction?.Act(controller);
   
    public void OnExit(StateMachine controller) => enterAction?.Act(controller);

}
