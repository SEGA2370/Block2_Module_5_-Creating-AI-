using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private IGameConfig _gameConfig;
    private int _currentHealth;
    private Animator _animator;

    private bool isDead = false;

    [Inject]
    public void Construct(IGameConfig gameConfig)
    {
        _gameConfig = gameConfig;
        _currentHealth = _gameConfig.PlayerHealth;
    }

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>(); // Ensure this line is present
        if (_animator == null)
        {
            Debug.LogError("Animator component not found on the Player object!");
            return;
        }

       // Debug.Log($"Player Health: {_gameConfig.PlayerHealth}");
       // Debug.Log($"Player Speed: {_gameConfig.PlayerSpeed}");
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        _currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current health: {_currentHealth}");
        
        if (_currentHealth <= 0)
        { 
            PlayDeathAnimation();
        }
        else
        {
            PlayHitAnimation();
        }
    }

    public void PlayHitAnimation()
    {
        if (isDead) return;
        _animator.SetTrigger("Hit");
        Debug.Log("Hit animation triggered.");
    }

    public void PlayDeathAnimation()
    {
        if (isDead) return;

        isDead = true;
        _animator.SetTrigger("Die");
        Debug.Log("Death animation triggered.");
    }
}

