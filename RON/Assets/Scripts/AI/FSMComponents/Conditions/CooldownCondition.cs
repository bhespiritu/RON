using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Condition/CooldownCondition")]
public class CooldownCondition : Condition
{
    public override bool evaluate(StateMachine controller)
    {
        return controller.currentState.cooldown < controller.timeSince;
    }
}