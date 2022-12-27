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

    [Inject]
    public void Construct(LevelPauser levelPauser)
    {
        _levelPauser = levelPauser;
        levelPauser.Subscribe(this);
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    private void Start()
    {
        StartMoving();
    }

    private void StartMoving()
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
        yield return new WaitForSeconds(_startDelay);

        while (true)
        {
            yield return MoveToDesiredPositionRoutine();
            yield return new WaitForSeconds(_delayBetweenMoving);


            if (_loop)
            {
                SwapPositions();
            }
        }
    }

    private IEnumerator MoveToDesiredPositionRoutine()
    {
        float timeElapsed = 0;

        while (timeElapsed <= 1)
        {
            if (_isPaused)
            {
                yield return null;
            }

            var value = _speedCurve.Evaluate(timeElapsed);
            var newPosition = Vector2.Lerp(_currentStartPosition.position, 
                _currentEndPosition.position, value);
            transform.position = newPosition;

            timeElapsed += Time.deltaTime / _moveTime;
            yield return null;
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
    }
}
