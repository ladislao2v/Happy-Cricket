using Code.StateMachine;
using Code.StateMachine.States;
using System;
using Code.Services.ScoreService;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Button = UnityEngine.UI.Button;

namespace Code.UI.Menu
{
    public class MenuOverlay : Overlay
    {
        [SerializeField] private RecordView _recordView;
        [SerializeField] private Button _playButton;

        private IStateMachine _stateMachine;
        private IScoreService _scoreService;

        [Inject]
        private void Construct(IStateMachine stateMachine, IScoreService scoreService)
        {
            _scoreService = scoreService;
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _recordView.Render(_scoreService.Record);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            _stateMachine.Enter<PreGameState>();
        }
    }
}