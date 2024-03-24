using Code.Services.AchievementsService;
using Code.Services.Factories.AchievementViewFactory;
using Code.Services.ScoreService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.UI.Achievements
{
    public class AchievementsOverlay : Overlay
    {
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private RecordView _recordView;
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _text;
        
        private IAchievementViewFactory _achievementViewFactory;
        private IAchievementsService _achievementsService;
        private IScoreService _scoreService;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IAchievementsService achievementsService, IAchievementViewFactory achievementViewFactory,
            IScoreService scoreService, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _scoreService = scoreService;
            _achievementsService = achievementsService;
            _achievementViewFactory = achievementViewFactory;
        }

        private void OnEnable()
        {
            _recordView.Render(_scoreService.Record);
            _achievementsService.Load(_scoreService.Record);
            _backButton.Subscribe(OnBackClicked);

            if (_achievementsService.OpenedAchievements.Count == 0)
            {
                _text.SetActive(true);
                return;
            }
            
            foreach (var achievement in _achievementsService.OpenedAchievements)
            {
                _achievementViewFactory.Create(achievement, _container);
            }
        }

        private void OnDisable()
        {
            _backButton.Unsubscribe(OnBackClicked);
        }

        private void OnBackClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}