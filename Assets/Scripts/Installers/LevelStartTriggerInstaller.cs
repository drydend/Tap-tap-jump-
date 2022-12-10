using UnityEditor.Tilemaps;
using UnityEngine;
using Zenject;

public class LevelStartTriggerInstaller : MonoInstaller
{
    [SerializeField]
    private LevelStartMenuUI _startMenuUi;

    public override void InstallBindings()
    {
        Container
            .Bind<ILevelStartTrigger>()
            .To<LevelStartMenuUI>()
            .FromInstance(_startMenuUi)
            .AsSingle();
    }
}
