using System;
using UnityEngine;
using Zenject;

public class GameBootstrap : MonoInstaller
{
    [SerializeField]
    private ConfigDataProvider _staticDataProvider;

    private SaveService _saveSerivce;
    private Game _game;
    private AnalitycsFacade _analitycs;

    private Settings _settings;

    public override void InstallBindings()
    {   
        Application.targetFrameRate = Screen.currentResolution.refreshRate + 10;
        var screenScaler = new CameraScaler(_staticDataProvider.CameraConfig);
        screenScaler.ScaleCamera();

        _saveSerivce = new SaveService(new JsonSaver());
        _game = new Game(_saveSerivce, new SceneLoader());
        _settings = _saveSerivce.GetData().Settings;
        _analitycs = new AnalitycsFacade(_game);

        _analitycs.SetupAnalitycs();
        InstallGame();
        InstallSaveService();
        InstallStaticDataProvider();
        InstallSettings();
        InstallAnalitycs();
    }

    private void InstallAnalitycs()
    {
        Container
           .Bind<AnalitycsFacade>()
           .FromInstance(_analitycs)
           .AsSingle();
    }

    private void InstallStaticDataProvider()
    {
        Container
            .Bind<ConfigDataProvider>()
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
