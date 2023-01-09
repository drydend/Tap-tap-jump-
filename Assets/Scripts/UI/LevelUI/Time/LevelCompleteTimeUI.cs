using System;
using System.Collections;
using UnityEngine;

public class LevelCompleteTimeUI : MonoBehaviour
{
    [SerializeField]
    private Level _level;

    [SerializeField]
    private TimeUI _timeUI;
    [SerializeField]
    private float _animationTime = 0.7f;

    private Coroutine _showTimeCoroutine;

    public void ShowTime()
    {
        _showTimeCoroutine = Coroutines.StartRoutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        float timeElapsedNormalized = 0f;

        while(timeElapsedNormalized != 1)
        {
            var time = Mathf.Lerp(0, _level.LastCompleteTime, timeElapsedNormalized);
            _timeUI.SetTime(time);

            timeElapsedNormalized += Mathf.Clamp(timeElapsedNormalized + Time.deltaTime / _animationTime, 0f, 1f);
            yield return null;
        }
    }

    private void OnDisable()
    {
        if(_showTimeCoroutine!= null)
        {
            Coroutines.StopRoutine(_showTimeCoroutine);
        }
    }
}
