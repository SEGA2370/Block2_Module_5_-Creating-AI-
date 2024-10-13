using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private IGameConfig _gameConfig;

    [Inject]
    public void Construct(IGameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    private void Start()
    {
        Debug.Log($"Player Health: {_gameConfig.PlayerHealth}");
        Debug.Log($"Player Speed: {_gameConfig.PlayerSpeed}");
    }
}

