using UnityEngine;
using Zenject;

public class LevelPauserInstaller : MonoInstaller
{
    [SerializeField]
    private PauseMenuUI _pauseMenu;
    [SerializeField]
    private UIMenuHandler _menuHandler;

    private LevelPauser _levelPauser;

    public override void InstallBindings()
    {
        _levelPauser = new LevelPauser(_pauseMenu, _menuHandler);
        BindPauser();
    }

    private void BindPauser()
    {
        Container
            .Bind<LevelPauser>()
            .FromInstance(_levelPauser)
            .AsSingle();
    }
}
