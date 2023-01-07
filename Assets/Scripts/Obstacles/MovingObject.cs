using System.Collections;
using UnityEngine;
using Zenject;

public class MovingObject : MonoBehaviour, IPauseable
{
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private Transform _endPosition;
    [Space]
    [SerializeField]
    private AnimationCurve _speedCurve;
    [Space]
    [SerializeField]
    private float _moveTime;
    [SerializeField]
    private float _startDelay;
    [SerializeField]
    private float _delayBetweenMoving;

    [Space]
    [SerializeField]
    private bool _loop;

    private Transform _currentEndPosition;
    private Transform _currentStartPosition;

    private bool _isPaused;

    private LevelPauser _levelPauser;
    private MovingObjectStarter _starter;

    [Inject]
    public void Construct(LevelPauser levelPauser, MovingObjectStarter starter)
    {
        _levelPauser = levelPauser;
        _starter = starter;

        levelPauser.Subscribe(this);
        starter.Subscribe(this);
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    public void StartMoving()
    {
        ResetPositions();
        StartCoroutine(MovingRoutine());
    }

    private void ResetPositions()
    {
        _currentStartPosition = _startPosition;
        _currentEndPosition = _endPosition;
    }

    private IEnumerator MovingRoutine()
    {
        float timeElapsed = 0f;

        while(timeElapsed < _startDelay)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        float overTime = timeElapsed - _startDelay;

        while (true)
        {

            float animationTimeElapsed = overTime / _moveTime;

            while (animationTimeElapsed <= 1)
            {
                while (_isPaused)
                {
                    yield return null;
                }

                var value = _speedCurve.Evaluate(animationTimeElapsed);
                var newPosition = Vector2.Lerp(_currentStartPosition.position,
                    _currentEndPosition.position, value);
                transform.position = newPosition;

                animationTimeElapsed += Time.deltaTime / _moveTime;
                yield return null;
            }


            timeElapsed = 0;

            while (timeElapsed < _delayBetweenMoving)
            {
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            overTime = timeElapsed - _delayBetweenMoving ;
            overTime += (animationTimeElapsed - 1) * _moveTime;

            if (_loop)
            {
                SwapPositions();
            }
        }
    }

    private void SwapPositions()
    {
        var temp = _currentStartPosition;
        _currentStartPosition = _currentEndPosition;
        _currentEndPosition = temp;
    }

    private void OnDestroy()
    {
        _levelPauser.UnSubscribe(this);
        _starter.UnSubscribe(this);
    }
}
