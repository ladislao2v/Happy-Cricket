using System;
using Code.Services.StatsService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.UI.StatsInformation
{
    public class StatsOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private RecordView _challengeView;
        [SerializeField] private RecordView _matchView;
        [SerializeField] private RecordView _hitCountView;
        [SerializeField] private RecordView _missedCountView;
        
        private IStatsService _statsService;
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine, IStatsService statsService)
        {
            _stateMachine = stateMachine;
            _statsService = statsService;
        }

        private void OnEnable()
        {
            _backButton.Subscribe(OnBackButtonClicked);
            
            _challengeView.Render(_statsService.ChallengeWins);
            _matchView.Render(_statsService.MatchWins);
            _hitCountView.Render(_statsService.HitCount);
            _missedCountView.Render(_statsService.MissedCount);
        }

        private void OnDisable()
        {
            _backButton.Subscribe(OnBackButtonClicked);
        }

        public void OnBackButtonClicked()
        {
           _stateMachine.Enter<SaveDataState>();
        }
    }
}