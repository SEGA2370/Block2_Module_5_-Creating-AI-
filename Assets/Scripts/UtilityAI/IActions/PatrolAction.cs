using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : IAction
{
    private Transform _transform;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    public float Score { get; private set; }

    public PatrolAction(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
        Score = 0.5f;
    }

    public void Execute()
    {
        //Debug.Log("Executing PatrolAction");

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
            Vector3 targetPosition = new Vector3(wp.position.x, _transform.position.y, wp.position.z);

            if (Vector3.Distance(_transform.position, targetPosition) < 0.1f)
            {
                _transform.position = targetPosition;
                _waitCounter = 0;
                _waiting = true;
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }
            else
            {
                _transform.position = Vector3.MoveTowards(_transform.position, targetPosition, GuardUAI.speed * Time.deltaTime);
                _transform.LookAt(new Vector3(wp.position.x, _transform.position.y, wp.position.z));
            }
        }
    }
}