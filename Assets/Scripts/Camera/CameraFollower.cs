using ModestTree;
using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float _lerpFactor;
    [SerializeField]
    private float _lerpScale;

    [SerializeField]
    private Transform _maxYPosition;
    [SerializeField]
    private Transform _minYPosition;

    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    public void ResetPosition()
    {
        var yPosition = Mathf.Clamp(_player.transform.position.y, _minYPosition.position.y, _maxYPosition.position.y);
        var desiredPosition = new Vector3(transform.position.x, yPosition, -10);
        transform.position = desiredPosition;
    }


    private void Awake()
    {
        transform.position = new Vector3 (transform.position.x,_player.transform.position.y, -10);
    }

    private void LateUpdate()
    {
        var yPosition = Mathf.Clamp(_player.transform.position.y, _minYPosition.position.y, _maxYPosition.position.y);
        var desiredPosition = new Vector3(transform.position.x, yPosition, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _lerpFactor * Time.deltaTime * _lerpScale);
    }
}
