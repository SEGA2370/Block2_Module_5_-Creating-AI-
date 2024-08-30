using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardUAI : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform enemy;
    public static float speed = 3.5f;
    public float fovRange = 10f;
    public float attackRange = 2f;
    public float followDistance = 8f;

    private UtilityAI _utilityAI;
    private PatrolAction _patrolAction;
    private FollowAction _followAction;
    private AttackAction _attackAction;
    private EnemyInFOVConsideration _enemyInFOV;
    private EnemyInRangeConsideration _enemyInRange;

    private void Start()
    {
        // Actions
        _patrolAction = new PatrolAction(transform, waypoints);
        _followAction = new FollowAction(transform, enemy, followDistance);
        _attackAction = new AttackAction(transform, enemy, attackRange);

        // Considerations
        _enemyInFOV = new EnemyInFOVConsideration(transform, enemy, fovRange);
        _enemyInRange = new EnemyInRangeConsideration(transform, enemy, attackRange);

        // Add actions to the AI
        _utilityAI = new UtilityAI(new List<IAction> { _patrolAction, _followAction, _attackAction });
    }

    private void Update()
    {
        _followAction.Score = _enemyInFOV.GetScore();
        _attackAction.Score = _enemyInRange.GetScore();

        Debug.Log($"Follow Score: {_followAction.Score}, Attack Score: {_attackAction.Score}");

        // Decide and act based on the updated scores
        _utilityAI.DecideAndAct();
    }
}
