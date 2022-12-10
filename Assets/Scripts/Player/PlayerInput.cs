using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerInput : MonoBehaviour, IPointerDownHandler
{
    private Player _player;
    private Camera _camera;

    public event Action OnPlayerTap;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPlayerTap?.Invoke();

        var clickPosition = _camera.ScreenToWorldPoint(eventData.position);
        var directionToPlayer = _player.transform.position - clickPosition;
        _player.SetVelocity(directionToPlayer.normalized * Mathf.Clamp(directionToPlayer.magnitude * 5, 3, 20));
    }


    private void Awake()
    {
        _camera = Camera.main;
    }
}
