using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class LevelStartMenuUI : LevelUI, ILevelStartTrigger
{
    [SerializeField]
    private PlayerInput _input;
    private bool _triggered;

    public event Action OnLevelStart;

    public void TriggerLevelStart()
    {
        if (_triggered)
        {
            return;
        }

        _triggered = true;
        OnLevelStart?.Invoke();
    }

    private void Awake()
    {
        _input.OnPlayerTap += TriggerLevelStart;
    }

}
