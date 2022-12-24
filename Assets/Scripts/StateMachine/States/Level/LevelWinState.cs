using System.Collections;
using UnityEngine;

public class LevelWinState : BaseState
{
    private Player _player;
    private Level _level;
    private PlayerInput _playerInput;
    private LevelCompleteScrene _levelCompleteScrene;

    private Coroutine _closingCoroutine;
    private Coroutine _openignCoroutine;

    public LevelWinState(Player player,Level level ,PlayerInput playerInput , LevelCompleteScrene levelCompleteScrene)
    {
        _player = player;
        _level = level;
        _levelCompleteScrene = levelCompleteScrene;
        _playerInput = playerInput;
    }

    public override void Enter()
    {
        _playerInput.DisableInput();
        _level.OnLevelCompleated();

        if(_openignCoroutine != null)
        {
            Coroutines.StopRoutine(_openignCoroutine);
        }

        if (_closingCoroutine != null)
        {
            Coroutines.StopRoutine(_closingCoroutine);
        }

        _openignCoroutine = Coroutines.StartRoutine(EnterRoutine());
    }

    public override void Exit()
    {
        if (_openignCoroutine != null)
        {
            Coroutines.StopRoutine(_openignCoroutine);
        }

        if (_closingCoroutine != null)
        {
            Coroutines.StopRoutine(_closingCoroutine);
        }

        _playerInput.EnableInput();
        _closingCoroutine = Coroutines.StartRoutine(_levelCompleteScrene.Close());
    }

    private IEnumerator EnterRoutine()
    {
        yield return _player.SmoothStopRoutine();
        yield return _levelCompleteScrene.Open();
    }
}