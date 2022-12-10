using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour
{
    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}
