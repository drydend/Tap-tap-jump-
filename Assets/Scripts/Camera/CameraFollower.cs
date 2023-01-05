using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour, IResetable
{   
    private static float _yOffSet = 0f;
    private static float _cameraSize = 25f;

    [SerializeField, Range(0f, 1f)]
    private float _lerpFactor;
    [SerializeField]
    private float _lerpScale;

    [SerializeField]
    private Transform _maxYPosition;
    [SerializeField]
    private Transform _minYPosition;

    private Player _player;

    public static void SetScaleValues(float yOffSet, float cameraSize)
    {
        _yOffSet = yOffSet;
        _cameraSize = cameraSize;
    }

    [Inject]
    public void Construct(Player player, LevelReseter reseter)
    {
        _player = player;
        reseter.Subscribe(this);
    }
    public void ResetState()
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        var yPosition = Mathf.Clamp(_player.transform.position.y, _minYPosition.position.y + _yOffSet
            , _maxYPosition.position.y - _yOffSet);
        var desiredPosition = new Vector3(transform.position.x, yPosition, -10);
        transform.position = desiredPosition;
    }

    private void Awake()
    {   
        Camera.main.orthographicSize = _cameraSize;
        transform.position = new Vector3 (transform.position.x,_player.transform.position.y + _yOffSet, -10);
    }

    private void LateUpdate()
    {
        var yPosition = Mathf.Clamp(_player.transform.position.y, _minYPosition.position.y + _yOffSet,
            _maxYPosition.position.y - _yOffSet);
        var desiredPosition = new Vector3(transform.position.x, yPosition, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPosition,
            _lerpFactor * Time.deltaTime  * _lerpScale);
    }
}
