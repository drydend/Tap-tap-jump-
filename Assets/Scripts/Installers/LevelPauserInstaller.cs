using UnityEngine;
using Zenject;

public class LevelPauserInstaller : MonoInstaller
{
    [SerializeField]
    private PauseMenuUI _pauseMenu;

    private LevelPauser _levelPauser;

    public override void InstallBindings()
    {
        _levelPauser = new LevelPauser(_pauseMenu);
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
