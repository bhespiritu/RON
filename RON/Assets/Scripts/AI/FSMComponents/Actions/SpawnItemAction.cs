using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Action/SpawnItemAction")]
public class SpawnItemAction : Action
{
    public GameObject prefab;

    public override void Act(StateMachine controller)
    {
        Instantiate(prefab, controller.transform.position, Quaternion.identity);
    }
}
