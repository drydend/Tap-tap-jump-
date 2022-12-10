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
        _levelCompleteScrene.Open();
    }

    public override void Exit()
    {
        _levelCompleteScrene.Close();
    }
}