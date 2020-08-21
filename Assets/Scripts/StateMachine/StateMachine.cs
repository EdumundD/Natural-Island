using System;

public enum BaseState
{
    Resting,
    Eating,
    Moving,
    Hunting,
    BeingHunting,
    Growing
}

public abstract class State
{
    abstract public BaseState GetState { get; }
    abstract public void Enter(StateData data);
    abstract public void Execute(StateData data);
    abstract public void Exit(StateData data);
}

public class StateData
{
    public string data;
}

public class StateMachine
{
    private State currentState = null;
    private State previousState = null;
    private StateData data = null;

    public State CurrentState
    {
        get { return currentState; }
    }
    public State PreviousState
    {
        get { return previousState; }
    }

    public State GetState(BaseState state)
    {
        switch (state)
        {
            case BaseState.Moving: return new State_Moving();
            case BaseState.Rest: break;
            case BaseState.Resting: break;
        }
    }
    public void ChangeState(BaseState baseState, StateData data, StateData predata = null)
    {
        //要切换的状态就是当前状态，则return
        if (currentState != null && currentState.GetState == baseState)
            return;

        //退出上一个状态
        if (previousState != null)
            previousState.Exit(predata);

        //进入新状态
        currentState = GetState(baseState);
        this.data = data;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute(dataEvent);
        }
    }
}
