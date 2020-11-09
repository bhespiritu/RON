using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Condition/EnemyInfoCondition")]
public class EnemyInfoCondition : Condition
{
    public enum EnemyInfoField
    {
        HEALTH, DAZED_FOR, HURT_FOR, IS_DEAD
    }

    public enum CompareField
    {
        LESS,EQUAL,GREATER
    }

    public EnemyInfoField EnemyInfo;
    public CompareField Operation;
    public float Value;

    public override bool evaluate(StateMachine controller)
    {
        float info = -1;
        switch(EnemyInfo)
        {
            case EnemyInfoField.HEALTH: info = controller.enemyInfo.health; break;
            case EnemyInfoField.DAZED_FOR: info = controller.enemyInfo.dazedFor; break;
            case EnemyInfoField.HURT_FOR: info = controller.enemyInfo.hurtFor; break;
            case EnemyInfoField.IS_DEAD: return controller.enemyInfo.isDead;
        }
        switch(Operation)
        {
            case CompareField.EQUAL: return info == Value;
            case CompareField.LESS: return info < Value;
            case CompareField.GREATER: return info > Value;
        }
        return false;
    }
}

