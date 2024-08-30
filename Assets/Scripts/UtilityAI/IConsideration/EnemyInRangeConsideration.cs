using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRangeConsideration : IConsideration
{
    private Transform _transform;
    private Transform _enemy;
    private float _attackRange;

    public EnemyInRangeConsideration(Transform transform, Transform enemy, float attackRange)
    {
        _transform = transform;
        _enemy = enemy;
        _attackRange = attackRange;
    }

    public float GetScore()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform == _enemy)
            {
                return 2.0f;
            }
        }
        return 0.0f;
    }
}