using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerInput : MonoBehaviour, IPointerDownHandler
{
    private const float MaxXDirection = 0.714f; 

    private bool _invertControl;

    private Player _player;
    private Camera _camera;
    private bool _isActive = true;
    private Settings _settings;

    public event Action OnPlayerTap;



    [Inject]
    public void Construct(Player player, Settings settings)
    {
        _player = player;
        _settings = settings;
        _invertControl = settings.IsControlInverted;
        settings.IsControlInvertedChanged += UpdateInvertionOfControl;
    }

    public void DisableInput()
    {
        _isActive = false;
    }

    public void EnableInput()
    {
        _isActive = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isActive)
        {
            return;
        }

        OnPlayerTap?.Invoke();

        var clickPosition = _camera.ScreenToWorldPoint(eventData.position);
        var jumpDirection = (Vector2)(_camera.transform.position - clickPosition);
        jumpDirection.Normalize();

        if (!_invertControl)
        {
            jumpDirection.x *= -1;
        }

        _player.Jump(jumpDirection);
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        _settings.IsControlInvertedChanged -= UpdateInvertionOfControl;
    }

    private void UpdateInvertionOfControl()
    {
        _invertControl = _settings.IsControlInverted;
    }
}
