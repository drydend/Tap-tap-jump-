using System.Collections;
public class LevelStartState : BaseState
{
    private StateMachine _stateMachine;
    private Player _player;
    private LevelStartMenuUI _menuUI;

    public LevelStartState(StateMachine stateMachine, Player player , LevelStartMenuUI startMenu)
    {
        _stateMachine = stateMachine;
        _player = player;
        _menuUI = startMenu;
    }

    public override void Enter()
    {
        Coroutines.StartRoutine(_menuUI.Open());
        _player.DisableGravity();
        _player.ResetToStartState();
        _menuUI.OnLevelStart += StartGame;
    }

    public override void Exit()
    {
        Coroutines.StartRoutine(_menuUI.Close());
        _menuUI.OnLevelStart -= StartGame;
    }

    private void StartGame()
    {
        _stateMachine.SwitchState<LevelRuningState>();
    }
}
