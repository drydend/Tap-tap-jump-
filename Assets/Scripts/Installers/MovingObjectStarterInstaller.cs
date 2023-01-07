using UnityEngine;
using Zenject;

public class MovingObjectStarterInstaller : MonoInstaller
{
    [SerializeField]
    private MovingObjectStarter _movingObjestStarterPrefab;

    public override void InstallBindings()
    {
        Container
            .Bind<MovingObjectStarter>()
            .FromComponentInNewPrefab(_movingObjestStarterPrefab)
            .AsSingle();
    }
}
