using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInFOVConsideration : IConsideration
{
    private Transform _transform;
    private Transform _enemy;
    private float _fovRange;

    public EnemyInFOVConsideration(Transform transform, Transform enemy, float fovRange)
    {
        _transform = transform;
        _enemy = enemy;
        _fovRange = fovRange;
    }

    public float GetScore()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _fovRange);

        float distance = Vector3.Distance(_transform.position, _enemy.position);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform == _enemy)
            {
                return 1.0f;
            }
        }
        return 0.0f;
    }
}