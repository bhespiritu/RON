using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Action/Test/RotateAction")]
public class RotateAction : Action
{
    public float rotateOffset = 15;
    public override void Act(StateMachine controller)
    {
        controller.transform.localEulerAngles = (1 + rotateOffset * Mathf.Sin(GameTimer.time)) * Vector3.forward;
    }
}