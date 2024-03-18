using Code.Services.ScoreService;
using UnityEngine;
using Zenject;

namespace Code.UI.Gameplay
{
    public class GameplayOverlay : Overlay
    {
        [SerializeField] private ScoreView _scoreView;
        
        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            _scoreService.ScoreChanged += _scoreView.OnScoreChanged;
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= _scoreView.OnScoreChanged;
        }
    }
}