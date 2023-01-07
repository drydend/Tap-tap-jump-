using System.Collections;

public class LevelPauseState : BaseState
{
    private Player _player;
    private StateMachine _stateMachine;
    private LevelPauser _pauser;

    public LevelPauseState(Player player ,StateMachine stateMachine, LevelPauser levelPauser)
    {
        _player = player;
        _stateMachine = stateMachine;
        _pauser = levelPauser;
    }

    public override void Enter()
    {   
        _player.Pause();
        _pauser.OnLevelUnpaused += OnUnpause;
    }

    public override void Exit()
    {
        _pauser.OnLevelUnpaused -= OnUnpause;

        if (_pauser.IsPaused)
        {
            _pauser.UnPause();
        }
    }

    private void OnUnpause()
    {
        _player.Unpause();
        _stateMachine.SwitchToPreviousState();
    }
}
