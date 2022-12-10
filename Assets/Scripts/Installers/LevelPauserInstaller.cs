using Zenject;

public class LevelPauserInstaller : MonoInstaller
{
    private LevelPauser _levelPauser;

    public override void InstallBindings()
    {
        _levelPauser = new LevelPauser();
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
