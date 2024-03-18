using Code.StateMachine;
using Code.StateMachine.States;
using Code.Views.Ball;
using Zenject;

namespace Code.Triggers
{
    public class RestartGameTrigger : Trigger<BallView>
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        protected override void InteractWith(BallView view)
        {
            _stateMachine.Enter<GameloseState>();
        }
    }
}