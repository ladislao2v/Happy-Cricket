using Code.StateMachine.States;

namespace Code.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}