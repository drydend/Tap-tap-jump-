﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    protected Game _game;

    [SerializeField]
    private PlayerInput _playerInput;
    [SerializeField]
    private LevelTimer _levelTimer;

    private StateMachine _stateMachine;

    private Player _player;
    private LevelUIHolder _levelUIHolder;
    private LevelWinTrigger _winTrigger;
    private LevelPauser _pauser;
    private LevelReseter _reseter;

    private AnalitycsFacade _analitics;

    public float BestCompleteTime => _game.LevelsData[_game.CurrentLevelNumber].BestCompleteTime;
    public float LastCompleteTime { get; private set; }

    public Action OnComplete;

    [Inject]
    public void Construct(Game game, Player player, LevelUIHolder levelUIHolder,
        LevelWinTrigger levelWinTrigger, LevelPauser levelPauser, LevelReseter levelReseter,
        AnalitycsFacade analitycs)
    {
        _game = game;
        _player = player;
        _levelUIHolder = levelUIHolder;
        _winTrigger = levelWinTrigger;
        _pauser = levelPauser;
        _reseter = levelReseter;
        _analitics = analitycs;
    }

    public virtual void OnLevelCompleated()
    {
        _levelTimer.Stop();
        LastCompleteTime = _levelTimer.CurrentTime;

        _analitics.LogLevelCompleation(LastCompleteTime);
        _game.OnCurrentLevelCompleated(_levelTimer.CurrentTime);
        
        OnComplete?.Invoke();
    }

    public void RestartLevel()
    {
        _stateMachine.SwitchState<LevelStartState>();
        _reseter.ResetLevel();
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

        states[typeof(LevelStartState)] = new LevelStartState(_stateMachine, _player,_playerInput,
            _levelUIHolder.GetLevelUI<LevelStartMenuUI>(), _pauser);
        states[typeof(LevelRuningState)] = new LevelRuningState(_stateMachine,
            _levelUIHolder.GetLevelUI<LevelRuningStateUI>(), _player,_playerInput ,_winTrigger, _pauser);
        states[typeof(LevelWinState)] = new LevelWinState(_player, this, _playerInput, _levelUIHolder.GetLevelUI<CompleteScrene>());
        states[typeof(LevelLoseState)] = new LevelLoseState(_player, this, _levelUIHolder.GetLevelUI<LevelLoseScrene>());
        states[typeof(LevelPauseState)] = new LevelPauseState(_player, _stateMachine, _pauser);
    }

}
