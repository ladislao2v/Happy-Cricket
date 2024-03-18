using Code.Services.RandomPointsService;
using Code.Services.ScoreService;
using Code.UI.Gameplay;
using Code.Views.Stricker;
using UnityEngine;

namespace Code.StateMachine.States
{
    public class ChangePositionState : IState
    {
        private readonly GameplayOverlay _gameplayOverlay;
        private readonly StrikerView _strikerView;
        private readonly IScoreService _scoreService;
        private readonly IRandomPointsService _randomPointsService = new RandomPointsService();

        public ChangePositionState(GameplayOverlay gameplayOverlay, StrikerView strikerView, IScoreService scoreService)
        {
            _gameplayOverlay = gameplayOverlay;
            _strikerView = strikerView;
            _scoreService = scoreService;
        }
        public void Enter()
        {
            _gameplayOverlay.Show();

            var points = _randomPointsService.Get();
            _scoreService.Add(points);
            _strikerView.Run(points);
        }

        public void Exit()
        {
            _gameplayOverlay.Hide();
        }
    }
}