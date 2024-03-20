using Code.UI.Gamelose;
using Code.Views.Players;

namespace Code.StateMachine.States
{
    public class GameloseState : IState
    {
        private readonly GameloseOverlay _gameloseOverlay;
        private readonly StrikerView _strikerView;
        private readonly PitcherView _pitcherView;

        public GameloseState(GameloseOverlay gameloseOverlay, StrikerView strikerView, PitcherView pitcherView)
        {
            _gameloseOverlay = gameloseOverlay;
            _strikerView = strikerView;
            _pitcherView = pitcherView;
        }
        public void Enter()
        {
            _strikerView.Lose();
            _pitcherView.Win();
            _gameloseOverlay.Show();
        }

        public void Exit()
        {
            _gameloseOverlay.Hide();
        }
    }
}