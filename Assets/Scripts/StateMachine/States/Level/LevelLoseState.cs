using System.Collections;

public class LevelLoseState : BaseState
{   
    private Player _player;
    private LevelLoseScrene _loseScrene;

    public LevelLoseState(Player player, LevelLoseScrene levelLoseScrene)
    {
        _player = player;
        _loseScrene = levelLoseScrene;
    }

    public override void Enter()
    {
        Coroutines.StartRoutine(EnterRoutine());
    }

    public override void Exit()
    {
        _loseScrene.Close();
    }

    private IEnumerator EnterRoutine()
    {
        yield return _player.PlayDeathAnimation();
        _loseScrene.Open();
    }
}
