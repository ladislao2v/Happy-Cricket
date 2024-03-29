﻿using Code.Services.MovementService;
using Code.Services.ScoreService;
using Code.Services.StatsService;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.UI;
using Code.UI.Gameplay;
using Code.Views.Ball;
using Code.Views.Players;
using UnityEngine;
using Zenject;

namespace Code.Triggers
{
    public class MissTrigger : Trigger<BallView>
    {
        
        private IStateMachine _stateMachine;
        private GameplayOverlay _gameplayOverlay;
        private IScoreService _scoreService;
        private StrikerView _strikerView;
        private IStatsService _statsService;

        [Inject]
        private void Construct(IStateMachine stateMachine, GameplayOverlay gameplayOverlay, IScoreService scoreService,
            StrikerView strikerView,
            IStatsService statsService)
        {
            _statsService = statsService;
            _strikerView = strikerView;
            _scoreService = scoreService;
            _gameplayOverlay = gameplayOverlay;
            _stateMachine = stateMachine;
        }
        
        protected override void InteractWith(BallView view)
        {
            _gameplayOverlay.ShowMiss();
            _scoreService.Add(0);
            _statsService.AddMissedCount();
            
            if(_scoreService.CurrentThrow != 3 && _scoreService.CurrentThrow != 6)
                _stateMachine.Enter<PitcherThrowState>();
        }
    }
}