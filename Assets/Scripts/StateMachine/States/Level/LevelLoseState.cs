using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class LevelLoseState : BaseState
{
    private Level _level;
    private Player _player;
    private LevelLoseScrene _loseScrene;

    private Coroutine _openingCoroutine;

    public LevelLoseState(Player player, Level level ,LevelLoseScrene levelLoseScrene)
    {
        _level = level;
        _player = player;
        _loseScrene = levelLoseScrene;
    }

    public override void Enter()
    {
        if(_openingCoroutine != null)
        {
            Coroutines.StopRoutine(_openingCoroutine);
        }

        _openingCoroutine = Coroutines.StartRoutine(EnterRoutine());
    }

    public override void Exit()
    {
        if (_openingCoroutine != null)
        {
            Coroutines.StopRoutine(_openingCoroutine);
        }

        _loseScrene.Close();
    }

    private IEnumerator EnterRoutine()
    {
        yield return _loseScrene.Open();
        _level.RestartLevel();
    }
}
