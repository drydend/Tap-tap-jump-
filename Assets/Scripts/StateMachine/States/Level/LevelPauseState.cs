using System.Collections;

public class LevelPauseState : BaseState
{
    private StateMachine _stateMachine;
    private LevelPauser _pauser;
    private PauseMenuUI _menuUI;

    public LevelPauseState(StateMachine stateMachine, LevelPauser levelPauser, PauseMenuUI pauseMenu)
    {
        _stateMachine = stateMachine;
        _pauser = levelPauser;
        _menuUI = pauseMenu;
    }

    public override void Enter()
    {
        _pauser.OnLevelUnpaused += OnUnpause;
        _menuUI.Open();
    }

    public override void Exit()
    {
        _pauser.OnLevelUnpaused -= OnUnpause;
        _menuUI.Close();
    }

    private void OnUnpause()
    {
        _stateMachine.SwitchState<LevelRuningState>();
    }
}
