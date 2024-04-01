using Code.Services.ScoreService;
using Code.Services.StatsService;
using Code.UI.Gamelose;
using Code.UI.Gameplay;
using Code.Views.Players;

namespace Code.StateMachine.States
{
    public class GameloseState : IState
    {
        private readonly GameplayOverlay _gameplayOverlay;
        private readonly GameloseOverlay _gameloseOverlay;
        private readonly StrikerView _strikerView;
        private readonly PitcherView _pitcherView;
        private readonly IScoreService _scoreService;

        public GameloseState(GameplayOverlay gameplayOverlay, GameloseOverlay gameloseOverlay, StrikerView strikerView, 
            PitcherView pitcherView, IScoreService scoreService)
        {
            _gameplayOverlay = gameplayOverlay;
            _gameloseOverlay = gameloseOverlay;
            _strikerView = strikerView;
            _pitcherView = pitcherView;
            _scoreService = scoreService;
        }
        public void Enter()
        {
            _strikerView.Lose();
            _pitcherView.Win();
            _gameplayOverlay.Show();
            _gameloseOverlay.Show();
        }

        public void Exit()
        {
            _gameplayOverlay.Hide();
            _gameloseOverlay.Hide();
            _scoreService.Reset();
        }
    }
}