using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField]
    private CameraFollower _cameraFollower;

    private StateMachine _stateMachine;

    private Player _player;
    private LevelUIHolder _levelUIHolder;
    private LevelWinTrigger _winTrigger;
    private LevelPauser _pauser;

    [Inject]
    public void Construct(Player player, LevelUIHolder levelUIHolder, 
        LevelWinTrigger levelWinTrigger, LevelPauser levelPauser)
    {
        _player = player;
        _levelUIHolder = levelUIHolder;
        _winTrigger = levelWinTrigger;
        _pauser = levelPauser;
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

        states[typeof(LevelStartState)] =  new LevelStartState(_stateMachine, _player, 
            _levelUIHolder.GetLevelUI<LevelStartMenuUI>());
        states[typeof(LevelRuningState)] = new LevelRuningState(_stateMachine,
            _levelUIHolder.GetLevelUI<LevelRuningStateUI>(),_player, _winTrigger, _pauser);
        states[typeof(LevelWinState)] = new LevelWinState(_player, _levelUIHolder.GetLevelUI<LevelCompleteScrene>());
        states[typeof(LevelLoseState)] = new LevelLoseState(_player, this, _levelUIHolder.GetLevelUI<LevelLoseScrene>());
        states[typeof(LevelPauseState)] = new LevelPauseState(_player ,_stateMachine, _pauser);
    }

}
