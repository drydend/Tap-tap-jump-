using System.Collections;
using UnityEngine;
using Zenject;

public class LevelReseterInstaller : MonoInstaller
{
    private LevelReseter _levelReseter;

    public override void InstallBindings()
    {
        _levelReseter = new LevelReseter();

        Container
            .Bind<LevelReseter>()
            .FromInstance(_levelReseter)
            .AsSingle();
    }
}
