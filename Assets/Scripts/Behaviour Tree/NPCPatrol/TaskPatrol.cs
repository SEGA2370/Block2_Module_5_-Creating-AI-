using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
       if (_waiting)
    {
        _waitCounter += Time.deltaTime;
        if (_waitCounter > _waitTime)
        {
            _waiting = false;
        }
    }
    else
    {
        Transform wp = _waypoints[_currentWaypointIndex];
        
        // Создаем целевую позицию с сохранением текущей позиции по оси Y
        Vector3 targetPosition = new Vector3(wp.position.x, _transform.position.y, wp.position.z);

        if (Vector3.Distance(_transform.position, targetPosition) < 0.01f)
        {
            _transform.position = targetPosition;
            _waitCounter = 0;
            _waiting = true;

            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
        else
        {
            _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, GuardBT.speed * Time.deltaTime);
            _transform.LookAt(new Vector3(wp.position.x, _transform.position.y, wp.position.z)); // Зафиксируем LookAt на одной высоте
        }
    }

    state = NodeState.RUNNING;
    return state;
    }
}
