using Zenject;
using UnityEngine;
public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private CameraShaker _cameraShaker;

    [SerializeField]
    private Player _playerPrefab;
    private Player _playerInstance;

    public override void InstallBindings()
    {
        _playerInstance = Instantiate(_playerPrefab, _startPosition.position, Quaternion.identity);
        _playerInstance.Initialize(_startPosition, _cameraShaker);

        Container
            .Bind<Player>()
            .FromInstance(_playerInstance)
            .AsSingle();
    }
}
