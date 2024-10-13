using UnityEngine;
using Zenject;

public class GameConfigInstaller : MonoInstaller
{
    public GameConfigSO gameConfigSO;
    public bool useScriptableObjectConfig = true;

    public override void InstallBindings()
    {
        if (useScriptableObjectConfig)
        {
            Container.Bind<IGameConfig>().To<ScriptableObjectGameConfig>().AsSingle().WithArguments(gameConfigSO);
        }
        else
        {
            Container.Bind<IGameConfig>().To<DummyGameConfig>().AsSingle();
        }
    }
}

public interface IGameConfig
{
    int PlayerHealth { get; }
    float PlayerSpeed { get; }
}