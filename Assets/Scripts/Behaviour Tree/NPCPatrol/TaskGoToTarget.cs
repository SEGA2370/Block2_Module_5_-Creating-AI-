using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private float _attackRange;
    private float _sightRange;

    public TaskGoToTarget(Transform transform, float attackRange, float sightRange)
    {
        _transform = transform;
        _attackRange = attackRange;
        _sightRange = sightRange;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        float distanceToTarget = Vector3.Distance(_transform.position, target.position);

        // Check if the target is out of sight range
        if (distanceToTarget > _sightRange)
        {
            ClearData("target");
            state = NodeState.FAILURE;
            return state;
        }

        // Check if the target is within attack range
        if (distanceToTarget <= _attackRange)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        // Move towards the target
        _transform.position = Vector3.MoveTowards(
            _transform.position, target.position, GuardBT.speed * Time.deltaTime);
        _transform.LookAt(new Vector3(target.position.x, _transform.position.y, target.position.z));

        state = NodeState.RUNNING;
        return state;
    }
}
