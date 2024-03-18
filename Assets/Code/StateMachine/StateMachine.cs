using Code.Factories.StateFactory;
using Code.StateMachine.States;

namespace Code.StateMachine
{
    public class GameStateMachine : IStateMachine
    {
        private readonly IStatesFactory _statesFactory;
        private IState _currentState;

        public GameStateMachine(IStatesFactory statesFactory)
        {
            _statesFactory = statesFactory;
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _currentState?.Exit(); 
            TState state = _statesFactory.Create<TState>() as TState;
            _currentState = state;

            return state;
        }
    }
}
