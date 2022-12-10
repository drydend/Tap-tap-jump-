using System;
using UnityEngine;
using Zenject;

public class LevelUIHolderInstaller : MonoInstaller
{
    [SerializeField]
    private LevelUIHolder _levelUIHolder;

    public override void InstallBindings()
    {
        Container
            .Bind<LevelUIHolder>()
            .FromInstance(_levelUIHolder)
            .AsSingle();
    }
}
