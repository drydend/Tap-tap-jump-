using System;
using System.Collections.Generic;
using System.Collections;

public class StateMachine
{
    private Dictionary<Type, BaseState> _states;

    private BaseState _currentState;
    private BaseState _previousState;

    public StateMachine(Dictionary<Type, BaseState> states)
    {
        _states = states;
    }

    public void SwitchState<T>() where T : BaseState
    {
        if (_currentState != null)
        {
            _currentState.Exit();
            _previousState = _currentState;
        }

        _currentState = _states[typeof(T)];
        _currentState.Enter();
    }

    public void SwitchToPreviousState()
    {
        if (_previousState == null)
        {
            return;
        }

        _currentState.Exit();
        _currentState = _previousState;
        _currentState.Enter();
    }
}
