using UnityEngine;
using Zenject;

public class UIMenuHandlerInstaller : MonoInstaller
{
    [SerializeField]
    private UIMenuHandler _menuHandler;

    public override void InstallBindings()
    {
        Container
            .Bind<UIMenuHandler>()
            .FromInstance(_menuHandler)
            .AsSingle();
    }
}
