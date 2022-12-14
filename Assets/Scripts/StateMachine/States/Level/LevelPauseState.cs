using System.Collections;

public class LevelPauseState : BaseState
{
    private StateMachine _stateMachine;
    private LevelPauser _pauser;
    private PauseMenuUI _menuUI;

    private bool _isUIClosed;

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
        _isUIClosed = false;
    }

    public override void Exit()
    {
        _pauser.OnLevelUnpaused -= OnUnpause;

        if (_pauser.IsPaused)
        {
            _pauser.Unpause();
        }

        if (!_isUIClosed)
        {
            Coroutines.StartRoutine(_menuUI.Close());
        }
    }

    private void OnUnpause()
    {
        Coroutines.StartRoutine(OnUpauseRoutine());
    }

    private IEnumerator OnUpauseRoutine()
    {
        _isUIClosed = true;
        yield return _menuUI.Close();
        _stateMachine.SwitchToPreviousState();
    }
}
