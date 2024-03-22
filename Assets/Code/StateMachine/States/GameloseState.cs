using Code.Services.ScoreService;
using Code.UI.Gamelose;
using Code.Views.Players;

namespace Code.StateMachine.States
{
    public class GameloseState : IState
    {
        private readonly GameloseOverlay _gameloseOverlay;
        private readonly StrikerView _strikerView;
        private readonly PitcherView _pitcherView;
        private readonly IScoreService _scoreService;

        public GameloseState(GameloseOverlay gameloseOverlay, StrikerView strikerView, PitcherView pitcherView,
            IScoreService scoreService)
        {
            _gameloseOverlay = gameloseOverlay;
            _strikerView = strikerView;
            _pitcherView = pitcherView;
            _scoreService = scoreService;
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
            _scoreService.Reset();
        }
    }
}