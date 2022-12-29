using UnityEditor;
using UnityEngine;
using Zenject;

public class ChasingObstacleStartTrigger : MonoBehaviour, IResetable
{
    [SerializeField]
    private ChasingObstacle _chasingObstacle;

    private bool _hasTriggered;

    [Inject]
    public void Construct(LevelReseter reseter)
    {
        reseter.Subscribe(this);
    }

    public void ResetState()
    {
        _hasTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hasTriggered)
        {
            return;
        }

        if(collision.gameObject.TryGetComponent(out Player player))
        {
            _chasingObstacle.StartMovement();
            _hasTriggered = true;
        }
    }
}
