using Zenject;
using UnityEngine;
public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private Player _playerPrefab;
    public override void InstallBindings()
    {
        var player = Instantiate(_playerPrefab, _startPosition.position, Quaternion.identity);
        player.Initialize(_startPosition);

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
    }
}
