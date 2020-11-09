using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Action/Test/ScaleAction")]
public class ScaleAction : Action
{
    public float scaleOffset = 0.1f;

    public override void Act(StateMachine controller)
    {
        controller.transform.localScale = (1 + scaleOffset * Mathf.Sin(GameTimer.time)) * Vector3.one;
    }
}