using System;
using System.Collections;
using Code.Services.CoroutineRunner;
using Code.Services.PauseService;
using Code.Services.ScoreService;
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
        [SerializeField] private PauseButton _pauseButton;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private float _delay;

        private IScoreService _scoreService;
        private IPauseService _pauseService;
        private StrikerView _strikerView;
        private ICoroutineRunner _coroutineRunner;
        private Coroutine _showing;

        [Inject]
        private void Construct(IScoreService scoreService, IPauseService pauseService, 
            ICoroutineRunner coroutineRunner, StrikerView strikerView)
        {
            _coroutineRunner = coroutineRunner;
            _strikerView = strikerView;
            _pauseService = pauseService;
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            _scoreService.ScoreChanged += _scoreView.OnScoreChanged;
            _pauseButton.Subscribe(OnPauseClicked);
            _pauseView.Subscribe(OnResumeClicked);
            _strikerView.Kicked += ShowGood;
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= _scoreView.OnScoreChanged;
            _pauseButton.Unsubscribe(OnPauseClicked);
            _pauseView.Unsubscribe(OnResumeClicked);
            _strikerView.Kicked -= ShowGood;
        }

        public void ShowGood()
        {
            _coroutineRunner.StopCoroutine(_showing);
            _showing = _coroutineRunner.StartCoroutine(ShowSprite(_goodSprite));
        }

        public void ShowMiss()
        {
            _coroutineRunner.StopCoroutine(_showing);
            _showing = _coroutineRunner.StartCoroutine(ShowSprite(_missSprite));
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
            _pauseService.Resume();
        }

        private void OnPauseClicked(bool value)
        {
            _pauseService.Pause();
            _pauseView.Show();
        }
    }
}