using Zenject;

public class GameBootstrap : MonoInstaller
{
    private SaveService _saveSerivce;
    private Game _game;

    public override void InstallBindings()
    {
        _saveSerivce = new SaveService(new JsonSaver());
        _game = new Game(_saveSerivce, new SceneLoader());

        InstallSaveService();
        InstallGame();
    }

    public override void Start()
    {
        _game.StartGame();
    }

    private void InstallGame()
    {
        Container
            .Bind<Game>()
            .FromInstance(_game)
            .AsSingle();
    }

    private void InstallSaveService()
    {
        Container
            .Bind<SaveService>()
            .FromInstance(_saveSerivce)
            .AsSingle();
    }
}
