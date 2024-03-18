using Code.StateMachine.States;
using Zenject;

namespace Code.Factories.StateFactory
{
    public class StatesFactory : IStatesFactory
    {
        private readonly DiContainer _container;

        public StatesFactory(DiContainer container)
        {
            _container = container;
        }

        public IState Create<TState>() where TState : class, IState
        {
            return _container.Instantiate<TState>();
        }
    }
}