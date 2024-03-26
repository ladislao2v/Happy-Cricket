using System;
using System.Collections;
using Code.Services.CoroutineRunner;
using Code.Services.MovementService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Services.StatsService;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.Views.Players;
using ModestTree.Util;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Gameplay
{
    public class GameplayOverlay : Overlay
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _goodSprite;
        [SerializeField] private Sprite _missSprite;
        [SerializeField] private PauseView _pauseView;
        [SerializeField] private HalfView _halfView;
        [SerializeField] private CustomButton _pauseButton;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private float _delay;

        private IScoreService _scoreService;
        private IPauseService _pauseService;
        private StrikerView _strikerView;
        private ICoroutineRunner _coroutineRunner;
        private Coroutine _showing;
        private IStatsService _statsService;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IScoreService scoreService, IPauseService pauseService, IStateMachine stateMachine,
            ICoroutineRunner coroutineRunner, StrikerView strikerView, IStatsService statsService)
        {
            _stateMachine = stateMachine;
            _statsService = statsService;
            _coroutineRunner = coroutineRunner;
            _strikerView = strikerView;
            _pauseService = pauseService;
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            _scoreService.ScoreChanged += _scoreView.OnScoreChanged;
            _scoreView.SetTarget(_scoreService.TargetScore);
            _pauseButton.Subscribe(OnPauseClicked);
            _pauseView.Subscribe(OnResumeClicked);
            _strikerView.Kicked += ShowGood;
            _scoreView.OnHalf += OnHalf;
            _halfView.ContinueButton.Subscribe(OnContinue);
            _scoreView.OnFinish += _stateMachine.Enter<GameloseState>;
        }

        private void OnContinue()
        {
            _halfView.gameObject.SetActive(false);
            _stateMachine.Enter<PitcherThrowState>();
        }

        private void OnHalf()
        {
            _stateMachine.Enter<WaitState>();
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= _scoreView.OnScoreChanged;
            _pauseButton.Unsubscribe(OnPauseClicked);
            _pauseView.Unsubscribe(OnResumeClicked);
            _strikerView.Kicked -= ShowGood;
            _scoreView.OnHalf -= OnHalf;
            _scoreView.OnFinish -= _stateMachine.Enter<GameloseState>;
        }

        public void ShowGood()
        {
            if(_showing != null)
                _coroutineRunner.StopCoroutine(_showing);
            
            _showing = _coroutineRunner.StartCoroutine(ShowSprite(_goodSprite));
            
            _statsService.AddHitCount();
        }

        public void ShowMiss()
        {
            if(_showing != null)
                _coroutineRunner.StopCoroutine(_showing);
            
            _showing = _coroutineRunner.StartCoroutine(ShowSprite(_missSprite));
            
            _statsService.AddMissedCount();
        }

        private IEnumerator ShowSprite(Sprite sprite)
        {
            _image.sprite = sprite;
            _image.enabled = true;
            
            yield return new WaitForSeconds(_delay);
            
            _image.sprite = null;
            _image.enabled = false;
        }

        private void OnResumeClicked()
        {
            _pauseButton.gameObject.SetActive(true);
            _pauseService.Resume();
            Time.timeScale = 1;
        }

        private void OnPauseClicked()
        {
            Time.timeScale = 0;
            _pauseService.Pause();
            _pauseView.Show();
            _pauseButton.gameObject.SetActive(false);
        }
    }
}