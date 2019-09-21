﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>{
    public State<T> curState { get; set;}
    public T owner;
    public StateMachine(T _owner)
    {
        owner = _owner;
        curState = null;
    }

    public void ChangeState(State<T> _newstate)
    {
        if (curState != null)
            curState.ExitState(owner);
        curState = _newstate;
        curState.EnterState(owner);
    }

    public void Update()
    {
        if (curState != null)
            curState.UpdateState(owner);
    }
}

