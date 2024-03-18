using Code.Services.ScoreService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Gamelose
{
    public class GameloseOverlay : Overlay
    {
        [SerializeField] private RecordView _recordView;
        [SerializeField] private Button _restartButton;
        
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
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _recordView.Render(_scoreService.Record);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}