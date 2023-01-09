using System;
using UnityEngine;

public class LevelTimerUI : MonoBehaviour
{
    [SerializeField]
    private LevelTimer _timer;
    [SerializeField]
    private TimeUI _timeUI;


    private void OnEnable()
    {
        _timer.OnCurrentTimeChanged += UpdateUi;
    }

    private void OnDisable()
    {
        _timer.OnCurrentTimeChanged -= UpdateUi;
    }

    private void UpdateUi()
    {
        _timeUI.SetTime(_timer.CurrentTime);
    }
}
