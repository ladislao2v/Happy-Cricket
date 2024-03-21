using Code.StateMachine;
using Code.StateMachine.States;
using Code.UI.DailyReward;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Settings
{
    public class SettingsOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private SoundButton _soundButton;
        [SerializeField] private CustomButton _backButton;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private void OnEnable()
        {
            _soundButton.TurnOn();
            _backButton.Subscribe(OnBackButtonClicked);
        }

        private void OnDisable()
        {
            _soundButton.TurnOff();
            _backButton.Unsubscribe(OnBackButtonClicked);
        }

        public void OnBackButtonClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}