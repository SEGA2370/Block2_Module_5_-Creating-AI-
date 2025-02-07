using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackAction : IAction
{
    private Transform _transform;
    private Transform _enemy;
    private float _attackRange;

    private float lastAttackTime = 0f; // Track the last attack time
    private const float attackCooldown = 3f; // Cooldown duration (3 seconds)

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
        // Ensure cooldown has passed
        if (Time.time - lastAttackTime < attackCooldown)
        {
            return;
        }

        // Check if the enemy is within the attack range using an overlap sphere
        Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _attackRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.transform == _enemy)
            {
                Debug.Log("Attacking the enemy!");

                // Apply damage to the player (if the enemy is a player)
                Player player = hitCollider.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(50); // Deal 50 damage
                }

                _transform.DOScale(Vector3.one * 0.2f, 0.2f).OnComplete(()
                    => _transform.DOScale(Vector3.one, 2.8f));

                // Update cooldown timer
                lastAttackTime = Time.time;

                return;
            }
        }
    }
}
