using Code.Services.HealthService;
using Code.Services.ScoreService;
using Code.UI.Gameplay;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.UI.Challenge
{
    public class ChallengeOverlay : Overlay
    {
        [SerializeField] private RecordView _recordView;
        [SerializeField] private PauseView _pauseView;
        [SerializeField] private LoseView _loseView;
        [SerializeField] private CustomButton _pauseButton;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private ChallengeBallView _challengeBallView;
        
        private IScoreService _scoreService;
        private IHealthService _healthService;

        [Inject]
        private void Construct(IScoreService scoreService, IHealthService healthService)
        {
            _healthService = healthService;
            _scoreService = scoreService;
        }
        
        private void OnEnable()
        {
            _healthService.HealthChanged += _healthView.OnHealthChanged;
            _healthService.Died += OnDied;
            _scoreService.ScoreChanged += OnScoreChanged;
            _pauseButton.Subscribe(OnPause);
            _pauseView.Subscribe(OnResume);
            
            _challengeBallView.Throw();
        }

        private void OnDied()
        {
            _recordView.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(false);
            _challengeBallView.Stop();
            _loseView.Show();
        }

        private void OnDisable()
        {
            _healthService.HealthChanged -= _healthView.OnHealthChanged;
            _scoreService.ScoreChanged -= OnScoreChanged;
            _pauseButton.Unsubscribe(OnPause);
            _pauseView.Unsubscribe(OnResume);
        }

        private void OnScoreChanged(int points, int score)
        {
            _recordView.Render(score);
        }

        private void OnResume()
        {
            _pauseButton.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

        private void OnPause()
        {
            _pauseView.Show();
            _pauseButton.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
}