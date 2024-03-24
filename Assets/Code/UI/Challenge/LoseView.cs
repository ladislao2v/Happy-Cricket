using Code.Services.ScoreService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.UI.Challenge
{
    public class LoseView : MonoBehaviour
    {
        [SerializeField] private RecordView _recordView;
        [SerializeField] private CustomButton _homeButton;
        
        private IScoreService _scoreService;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IScoreService scoreService, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _scoreService = scoreService;
        }

        public void Show()
        {
            _homeButton.Unsubscribe(_stateMachine.Enter<SaveDataState>);
            gameObject.SetActive(true);
            _recordView.Render(_scoreService.Score);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _homeButton.Unsubscribe(_stateMachine.Enter<SaveDataState>);
        }
    }
}