using Code.Services.InputService;
using Code.UI.Gameplay;
using Code.Views.Players;

namespace Code.StateMachine.States
{
    public class PitcherThrowState : IState
    {
        private readonly GameplayOverlay _gameplayOverlay;
        private readonly IInputService _inputService;
        private readonly PitcherView _pitcherView;

        public PitcherThrowState(GameplayOverlay gameplayOverlay,
            IInputService inputService,
            PitcherView pitcherView)
        {
            _gameplayOverlay = gameplayOverlay;
            _inputService = inputService;
            _pitcherView = pitcherView;
        }

        public void Enter()
        {
            _gameplayOverlay.Show();
            _inputService.Enable();
            _pitcherView.Swing();
        }

        public void Exit()
        {
            _inputService.Disable();
            _gameplayOverlay.Hide();
        }
    }
}
