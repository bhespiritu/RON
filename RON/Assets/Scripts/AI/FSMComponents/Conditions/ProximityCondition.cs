using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Condition/ProximityCondition")]
public class ProximityCondition : Condition
{
    public float range = 5;

    public override bool evaluate(StateMachine controller)
    {
        var target = controller.enemyInfo.target;
        Vector2 diff = target.position - controller.transform.position;
        Debug.DrawLine(target.position, controller.transform.position, Color.white);
        Debug.DrawRay(controller.transform.position, diff.normalized * range, Color.blue);

        return diff.sqrMagnitude < range * range;
    }
}
