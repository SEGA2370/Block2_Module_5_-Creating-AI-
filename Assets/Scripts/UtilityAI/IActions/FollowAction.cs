using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAction : IAction
{
    private Transform _transform;
    private Transform _enemy;
    private float _followDistance;

    public float Score { get; set; }

    public FollowAction(Transform transform, Transform enemy, float followDistance)
    {
        _transform = transform;
        _enemy = enemy;
        _followDistance = followDistance;
        Score = 1.0f; // Higher score for following
    }

    public void Execute()
    {
        float distanceToEnemy = Vector3.Distance(_transform.position, _enemy.position);
        if (distanceToEnemy > _followDistance)
        {
            Vector3 targetPosition = new Vector3(_enemy.position.x, _transform.position.y, _enemy.position.z);
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, GuardUAI.speed * Time.deltaTime);
            _transform.LookAt(new Vector3(_enemy.position.x, _transform.position.y, _enemy.position.z));
            //Debug.Log("Following");
        }
    }
}