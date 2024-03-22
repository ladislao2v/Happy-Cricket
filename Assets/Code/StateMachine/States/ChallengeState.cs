using Code.UI.Gameplay;

namespace Code.StateMachine.States
{
    public class ChallengeState : IState
    {
        private readonly GameplayOverlay _gameplayOverlay;

        public ChallengeState(GameplayOverlay gameplayOverlay)
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