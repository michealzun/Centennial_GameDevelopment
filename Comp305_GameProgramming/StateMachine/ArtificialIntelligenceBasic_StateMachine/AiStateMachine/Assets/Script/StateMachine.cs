using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

public abstract class State<T>
{
    public abstract void EnterState(T _owner);
    public abstract void UpdateState(T _owner);
    public abstract void ExitState(T _owner);
}

