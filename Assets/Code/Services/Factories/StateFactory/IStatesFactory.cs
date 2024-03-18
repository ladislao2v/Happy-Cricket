using Code.StateMachine.States;

namespace Code.Factories.StateFactory
{
    public interface IStatesFactory
    {
        IState Create<TState>() where TState : class, IState;
    }
}