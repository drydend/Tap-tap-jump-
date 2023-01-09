using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class LevelTimer : MonoBehaviour , IPauseable
{
    private bool _isPaused;
    public float CurrentTime { get; private set; }

    public Action OnCurrentTimeChanged;

    private Coroutine _updateCorooutine;

    [Inject]
    public void Construct(ILevelStartTrigger levelStartTrigger,LevelPauser pauser)
    {
        levelStartTrigger.OnLevelStart += ResetState;
        levelStartTrigger.OnLevelStart += StartCountingTime;
        pauser.Subscribe(this);
    }

    public void StartCountingTime()
    {
        if(_updateCorooutine != null)
        {
            return;
        }

        _updateCorooutine = Coroutines.StartRoutine(UpdateRoutine());
    }

    public void Stop()
    {
        if (_updateCorooutine != null)
        {
            Coroutines.StopRoutine(_updateCorooutine);
            _updateCorooutine = null;
        }
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
        CurrentTime = 0;
        OnCurrentTimeChanged?.Invoke();

        if (_updateCorooutine != null)
        {
            Coroutines.StopRoutine(_updateCorooutine);
            _updateCorooutine=null;
        }
    }

    private IEnumerator UpdateRoutine()
    {
        while (true)
        {
            while (_isPaused)
            {
                yield return null;
            }

            CurrentTime += Time.deltaTime;
            OnCurrentTimeChanged?.Invoke();

            yield return null;
        }
    }
}
