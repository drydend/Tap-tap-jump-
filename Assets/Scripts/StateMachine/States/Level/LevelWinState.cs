using System.Collections;

public class LevelWinState : BaseState
{
    private Player _player;
    private Level _level;
    private LevelCompleteScrene _levelCompleteScrene;

    public LevelWinState(Player player,Level level , LevelCompleteScrene levelCompleteScrene)
    {
        _player = player;
        _level = level;
        _levelCompleteScrene = levelCompleteScrene;
    }

    public override void Enter()
    {
        _level.OnLevelCompleated();
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