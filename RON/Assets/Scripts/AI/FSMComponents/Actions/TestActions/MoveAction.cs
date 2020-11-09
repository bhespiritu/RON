using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Action/Test/MoveAction")]
public class MoveAction : Action
{
    public float moveOffset = 7;
    public override void Act(StateMachine controller)
    {
        controller.transform.position += (moveOffset * Mathf.Sin(GameTimer.time)) * Vector3.right * Time.deltaTime;
    }
}
