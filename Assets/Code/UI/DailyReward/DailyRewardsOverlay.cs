using System;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.UI.DailyReward
{
    public class DailyRewardsOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private CustomButton _backButton;
        
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _backButton.Subscribe(OnBackButtonClicked);
        }

        private void OnDisable()
        {
            _backButton.Unsubscribe(OnBackButtonClicked);
        }

        public void OnBackButtonClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}