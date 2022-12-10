using UnityEngine;
using Zenject;

public class LevelWinTriggerInstaller : MonoInstaller
{
    [SerializeField]
    private LevelWinTrigger _levelWinTrigger;

    public override void InstallBindings()
    {
        Container
         .Bind<LevelWinTrigger>()
         .FromInstance(_levelWinTrigger)
         .AsSingle();
    }
}
