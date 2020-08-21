public class State_Moving : State
{
    private const BaseState state = BaseState.Moving;

    public override BaseState GetState { get { return state; } }
    public override void Enter(StateData data)
    {
    }

    public override void Execute(StateData data)
    {
    }

    public override void Exit(StateData data)
    {
    }
}