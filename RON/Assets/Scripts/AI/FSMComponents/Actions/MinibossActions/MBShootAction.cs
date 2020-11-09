using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBShootAction : Action
{
    public GameObject projectile;

    public override void Act(StateMachine controller)
    {
        Vector3 dir = Vector3.right * (controller.enemyInfo.facing ? -1 : 1);

        var proj = Instantiate(projectile, controller.transform.position + dir, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().velocity = dir*5;
        controller.animator.SetTrigger("Swing");
    }
}
