using System;
using Code.Services.ClubService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.UI.ClubInformation
{
    public class ClubInformationOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private ClubDataView _clubDataView;
        
        private IClubService _clubService;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IClubService clubService, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _clubService = clubService;
        }

        private void OnEnable()
        {
            _backButton.Subscribe(OnBackButtonClicked);
            _clubDataView.Construct(_clubService.ClubData);
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