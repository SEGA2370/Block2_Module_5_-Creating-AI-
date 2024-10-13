using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigSO.asset", menuName = "Installers/GameConfigSO.asset")]
public class GameConfigSO : ScriptableObject
{
    public int playerHealth;
    public float playerSpeed;
}

public class ScriptableObjectGameConfig : IGameConfig
{
    private GameConfigSO _gameConfig;

    public ScriptableObjectGameConfig(GameConfigSO gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public int PlayerHealth => _gameConfig.playerHealth;
    public float PlayerSpeed => _gameConfig.playerSpeed;
}

public class DummyGameConfig : IGameConfig
{
    public int PlayerHealth => 100;
    public float PlayerSpeed => 5.0f;
}