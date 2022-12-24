using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    protected Game _game;

    [SerializeField]
    private CameraFollower _cameraFollower;
    [SerializeField]
    private PlayerInput _playerInput;

    private StateMachine _stateMachine;

    private Player _player;
    private LevelUIHolder _levelUIHolder;
    private LevelWinTrigger _winTrigger;
    private LevelPauser _pauser;

    [Inject]
    public void Construct(Game game, Player player, LevelUIHolder levelUIHolder,
        LevelWinTrigger levelWinTrigger, LevelPauser levelPauser)
    {
        _game = game;
        _player = player;
        _levelUIHolder = levelUIHolder;
        _winTrigger = levelWinTrigger;
        _pauser = levelPauser;
    }

    public virtual void OnLevelCompleated()
    {
        _game.OnCurrentLevelCompleated();
    }

    public void RestartLevel()
    {
        _stateMachine.SwitchState<LevelStartState>();
        _cameraFollower.ResetPosition();
    }

    private void Awake()
    {
        InitializeStates();
    }

    private void Start()
    {
        _stateMachine.SwitchState<LevelStartState>();
    }

    private void InitializeStates()
    {
        var states = new Dictionary<Type, BaseState>();
        _stateMachine = new StateMachine(states);

        states[typeof(LevelStartState)] = new LevelStartState(_stateMachine, _player,
            _levelUIHolder.GetLevelUI<LevelStartMenuUI>());
        states[typeof(LevelRuningState)] = new LevelRuningState(_stateMachine,
            _levelUIHolder.GetLevelUI<LevelRuningStateUI>(), _player, _winTrigger, _pauser);
        states[typeof(LevelWinState)] = new LevelWinState(_player, this, _playerInput, _levelUIHolder.GetLevelUI<LevelCompleteScrene>());
        states[typeof(LevelLoseState)] = new LevelLoseState(_player, this, _levelUIHolder.GetLevelUI<LevelLoseScrene>());
        states[typeof(LevelPauseState)] = new LevelPauseState(_player, _stateMachine, _pauser);
    }

}
