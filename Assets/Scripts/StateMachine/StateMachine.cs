using System;
using System.Collections.Generic;
using System.Collections;

public class StateMachine
{
    private Dictionary<Type, BaseState> _states;

    private BaseState _currentState;

    public StateMachine(Dictionary<Type, BaseState> states)
    {
        _states = states;
    }

    public void SwitchState<T>() where T : BaseState
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = _states[typeof(T)];
        _currentState.Enter();
    }
}
