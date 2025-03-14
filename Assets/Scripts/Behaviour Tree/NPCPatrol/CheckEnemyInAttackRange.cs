using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInAttackRange : Node
{
   // private static int _enemyLayermask = 1 << 6;

    private Transform _transform;

    public CheckEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform) t;
        if (Vector3.Distance(_transform.position, target.position) <= GuardBT.attackRange)
        {
            Debug.Log("Attacking");

            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
