using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Action/GoToWaypoint")]
public class GoToWaypoint : Action
{
    public override void Act(StateMachine controller)
    {
        Vector3 diff = controller.waypoint - (Vector2) controller.transform.position;
        controller.transform.position += diff * 0.5f * Time.deltaTime;

        controller.sprite.flipX = (diff.x < 0);
        controller.animator.SetBool("isRunning", Mathf.Abs(diff.x * 0.5f * Time.deltaTime) > 0.01f);

    }
}
