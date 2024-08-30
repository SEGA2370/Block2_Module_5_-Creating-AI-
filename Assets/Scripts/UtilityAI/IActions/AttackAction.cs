using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : IAction
{
    private Transform _transform;
    private Transform _enemy;
    private float _attackRange;

    public float Score { get; set; }

    public AttackAction(Transform transform, Transform enemy, float attackRange)
    {
        _transform = transform;
        _enemy = enemy;
        _attackRange = attackRange;
        Score = 2.0f; // Highest score for attacking
    }

    public void Execute()
    {
        // Check if the enemy is within the attack range using an overlap sphere
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform == _enemy)
            {
                Debug.Log("Attacking");
                return;
            }
        }
    }
}
