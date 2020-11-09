using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
    public Condition[] conditions;
    public bool[] invert;
    public State toState;

    public bool cyclic;

    [Range(0,1)]
    public float weight = 1;
    public bool canTransition(StateMachine controller)
    {
        bool canTransition = true;
        for(int i = 0; i < conditions.Length; i++)
        {
            Condition cond = conditions[i];
            bool inv = invert[i];
            if (!cond.evaluate(controller) ^ inv) canTransition = false;
        }
        return canTransition;
    }
}
