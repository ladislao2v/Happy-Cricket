using System;
using Code.Services.TimerService;
using Code.UI.Gameplay;
using UnityEngine;
using Zenject;

namespace Code.UI.Timer
{
    public class TimerOverlay : Overlay
    {
        [SerializeField] private GameObject _background;
        [SerializeField] private CustomButton _readyButton;
        [SerializeField] private TimerView _timerView;
        
        private ITimer _timer;

        public event Action Ready; 

        [Inject]
        private void Construct(ITimer timer)
        {
            _timer = timer;
        }

        private void OnEnable()
        {
            _background.SetActive(false);
            _readyButton.gameObject.SetActive(true);
            _timerView.gameObject.SetActive(false);
            
            _readyButton.Subscribe(OnReadyClicked);
            _timer.Ticked += _timerView.Render;
        }

        private void OnDisable()
        {
            _timer.Ticked -= _timerView.Render;
            _readyButton.Subscribe(OnReadyClicked);
        }

        private void OnReadyClicked()
        {
            Ready?.Invoke();
            _readyButton.gameObject.SetActive(false);
            _timerView.gameObject.SetActive(true);
        }
    }
}