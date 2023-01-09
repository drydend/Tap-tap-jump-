using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerInput : MonoBehaviour, IPointerDownHandler
{
    private const float MaxAngle = 45f;

    private bool _isControlInverted;

    private Player _player;
    private Settings _settings;
    private CameraConfig _cameraConfig;

    private Camera _camera;
    private bool _isActive = true;

    public event Action OnPlayerTap;

    [Inject]
    public void Construct(Player player, Settings settings, StaticDataProvider staticDataProvider)
    {
        _player = player;
        _settings = settings;
        _cameraConfig = staticDataProvider.CameraConfig;

        _isControlInverted = settings.IsControlInverted;
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

        float clickPositionX = _camera.transform.position.x - 
            _camera.ScreenToWorldPoint(eventData.position).x;
        float direction = clickPositionX > 0 ? 1 : -1;

        float angle = Mathf.Lerp(0, MaxAngle, Mathf.Abs(clickPositionX) / _cameraConfig.DesiredWidth);
        var jumpDirection = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));

        jumpDirection.x *= direction;
        jumpDirection.x *= _isControlInverted.ToInt();

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
        _isControlInverted = _settings.IsControlInverted;
    }
}
