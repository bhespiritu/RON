using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Condition/RandomCondition")]
public class RandomCondition : Condition
{
    [Range(0, 1)]
    public float chance = 0.5f;

    public override bool evaluate(StateMachine controller)
    {
        return Random.value < chance;
    }
}
