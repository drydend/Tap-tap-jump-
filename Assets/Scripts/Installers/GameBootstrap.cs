using UnityEngine;
using Zenject;

public class GameBootstrap : MonoInstaller
{
    private SaveService _saveSerivce;
    private Game _game;

    private Settings _settings;

    public override void InstallBindings()
    {   
        Application.targetFrameRate = Screen.currentResolution.refreshRate + 10;

        _saveSerivce = new SaveService(new JsonSaver());
        _game = new Game(_saveSerivce, new SceneLoader());
        _settings = _saveSerivce.GetData().Settings;


        InstallGame();
        InstallSaveService();

        InstallSettings();
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
