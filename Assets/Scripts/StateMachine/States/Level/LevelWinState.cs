using System.Collections;

public class LevelWinState : BaseState
{
    private LevelCompleteScrene _levelCompleteScrene;
    private Player _player;

    public LevelWinState(Player player, LevelCompleteScrene levelCompleteScrene)
    {
        _player = player;
        _levelCompleteScrene = levelCompleteScrene;
    }

    public override void Enter()
    {
        Coroutines.StartRoutine(EnterRoutine());
    }

    public override void Exit()
    {
        _levelCompleteScrene.Close();
    }

    private IEnumerator EnterRoutine()
    {
        yield return _player.SmoothStopRoutine();
        _levelCompleteScrene.Open();
    }
}