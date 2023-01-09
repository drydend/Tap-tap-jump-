using UnityEngine;
using Zenject;

public class GameBootstrap : MonoInstaller
{
    [SerializeField]
    private StaticDataProvider _staticDataProvider;

    private SaveService _saveSerivce;
    private Game _game;

    private Settings _settings;

    public override void InstallBindings()
    {   
        Application.targetFrameRate = Screen.currentResolution.refreshRate + 10;
        var screenScaler = new CameraScaler(_staticDataProvider.CameraConfig);
        screenScaler.ScaleCamera();

        _saveSerivce = new SaveService(new JsonSaver());
        _game = new Game(_saveSerivce, new SceneLoader());
        _settings = _saveSerivce.GetData().Settings;


        InstallGame();
        InstallSaveService();
        InstallStaticDataProvider();
        InstallSettings();
    }

    private void InstallStaticDataProvider()
    {
        Container
            .Bind<StaticDataProvider>()
            .FromComponentInNewPrefab(_staticDataProvider)
            .AsSingle()
            .NonLazy();
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

    private void InstallSettings()
    {
        Container
            .Bind<Settings>()
            .FromInstance(_settings)
            .AsSingle();
    }
}
