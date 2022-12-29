using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class ChasingObstacle : MonoBehaviour, IPauseable, IResetable
{
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private Transform _endPosition;
    [SerializeField]
    private float _movementSpeed;

    private Coroutine _moveCoroutine;
    private bool _isPaused;
    private bool _isActive;

    [Inject]
    public void Construct(LevelPauser levelPauser, LevelReseter reseter)
    {
        levelPauser.Subscribe(this);
        reseter.Subscribe(this);
    }

    public void StartMovement()
    {
        if(_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(MoveRoutine());
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    public void ResetState()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _isActive = false;
        transform.position = _startPosition.position;
    }

    private IEnumerator MoveRoutine()
    {   
        _isActive = true;

        while (transform.position != _endPosition.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, _endPosition.position
                , _movementSpeed * Time.deltaTime);
            
            while (_isPaused)
            {
                yield return null;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isActive)
        {
            return;
        }

        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.Die();
        }

        _isActive = false;
    }
}
