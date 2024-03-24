using Code.UI.Gameplay;
using Code.Views.Players;

namespace Code.StateMachine.States
{
    public class WaitState : IState
    {
        private readonly GameplayOverlay _gameplayOverlay;
        
        public WaitState(GameplayOverlay gameplayOverlay)
        {
            _gameplayOverlay = gameplayOverlay;
        }
        
        public void Enter()
        {
            _gameplayOverlay.Show();
        }

        public void Exit()
        {
            _gameplayOverlay.Hide();
        }
    }
}