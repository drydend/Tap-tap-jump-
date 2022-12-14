using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelStartMenuUI : LevelUI, ILevelStartTrigger
{
    [SerializeField]
    private PlayerInput _input;

    public event Action OnLevelStart;

    public override void Close()
    {
        base.Close();
        _input.OnPlayerTap -= TriggerLevelStart;
    }

    public override void Open()
    {
        base.Open();
        _input.OnPlayerTap += TriggerLevelStart;
    }

    private void TriggerLevelStart()
    {
        OnLevelStart?.Invoke();
    }
}
