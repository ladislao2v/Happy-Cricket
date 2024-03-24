using Code.Services.ClubService;
using Code.Services.DailyRewardService;
using Code.Services.StaticDataService;
using Code.StateMachine;
using Code.StateMachine.States;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.ClubCreation
{
    public class ClubCreationOverlay : Overlay
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private CustomButton _enterButton;
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private ClubIconSelector _clubIconSelector;
        
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
            _backButton.Subscribe(OnBackClicked);
            _enterButton.Subscribe(OnEnterButtonClicked);
            _clubIconSelector.Show();

            if(_clubService.IsCreated == false)
                _enterButton.gameObject.SetActive(true);
            else
            {
                _backButton.gameObject.SetActive(true);
                _inputField.text = _clubService.ClubData.Name;
                _clubIconSelector.Construct(_clubService.ClubData.IndexLogo);
            }
        }

        private void OnDisable()
        {
            _clubIconSelector.Hide();
            _enterButton.Unsubscribe(OnEnterButtonClicked);
            _backButton.Unsubscribe(OnBackClicked);
        }

        private void OnBackClicked()
        {
            if (_inputField.text == "")
                return;
            
            if(_clubIconSelector.SelectedIcon == null)
                return;

            ClubData clubData = 
                new ClubData(_clubIconSelector.SelectedIcon, _inputField.text);

            _clubService.CreateClub(clubData);
            
            _stateMachine.Enter<SaveDataState>();
        }

        private void OnEnterButtonClicked()
        {
            if (_inputField.text == "")
                return;
            
            if(_clubIconSelector.SelectedIcon == null)
                return;

            ClubData clubData = 
                new ClubData(_clubIconSelector.SelectedIcon, _inputField.text);

            _clubService.CreateClub(clubData);
            
            _stateMachine.Enter<DailyRewardsState>();
        }
    }
}