using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelStartMenuUI : AnimatedUIMenu, ILevelStartTrigger
{
    [SerializeField]
    private PlayerInput _input;

    public event Action OnLevelStart;

    public override IEnumerator Close()
    {
        _input.OnPlayerTap -= TriggerLevelStart;
        yield return base.Close();
    }

    public override IEnumerator Open()
    {
        _input.OnPlayerTap += TriggerLevelStart;
        yield return base.Open();
    }

    private void TriggerLevelStart()
    {
        OnLevelStart?.Invoke();
    }
}
