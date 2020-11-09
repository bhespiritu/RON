using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Action/RandomWaypoint")]
public class RandomWaypoint : Action
{
    public float maxDist = 1;

    public override void Act(StateMachine controller)
    {
        float dir = Random.value * 2 - 1;
        controller.waypoint = (Vector2) controller.transform.position + Vector2.right * maxDist * dir;
    }
}
