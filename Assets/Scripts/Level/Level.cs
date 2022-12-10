using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
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
        states[typeof(LevelLoseState)] = new LevelLoseState(_player, _levelUIHolder.GetLevelUI<LevelLoseScrene>());
        states[typeof(LevelPauseState)] = new LevelPauseState(_stateMachine, _pauser, 
            _levelUIHolder.GetLevelUI<PauseMenuUI>());
    }

}
