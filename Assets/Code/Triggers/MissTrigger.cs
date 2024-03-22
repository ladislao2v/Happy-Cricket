using Code.StateMachine;
using Code.StateMachine.States;
using Code.UI.Gameplay;
using Code.Views.Ball;
using Zenject;

namespace Code.Triggers
{
    public class MissTrigger : Trigger<BallView>
    {
        private IStateMachine _stateMachine;
        private GameplayOverlay _gameplayOverlay;

        [Inject]
        private void Construct(IStateMachine stateMachine, GameplayOverlay gameplayOverlay)
        {
            _gameplayOverlay = gameplayOverlay;
            _stateMachine = stateMachine;
        }
        
        protected override void InteractWith(BallView view)
        {
            _gameplayOverlay.ShowMiss();
        }
    }
}