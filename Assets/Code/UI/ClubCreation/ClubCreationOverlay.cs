using Code.Services.ClubService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.ClubCreation
{
    public class ClubCreationOverlay : Overlay
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private CustomButton _enterButton;
        [SerializeField] private ClubIconSelector _clubIconSelector;
        
        private IClubService _clubService;

        [Inject]
        private void Construct(IClubService clubService)
        {
            _clubService = clubService;
        }

        private void OnEnable()
        {
            _enterButton.Subscribe(OnEnterButtonClicked);
            _clubIconSelector.Show();
        }

        private void OnDisable()
        {
            _clubIconSelector.Hide();
            _enterButton.Unsubscribe(OnEnterButtonClicked);
        }

        private void OnEnterButtonClicked()
        {
            if (_inputField.text == "")
                return;
            
            if(_clubIconSelector.SelectedIcon == null)
                return;

            IClubData clubData = 
                new ClubData(_clubIconSelector.SelectedIcon, _inputField.text);

            _clubService.CreateClub(clubData);
        }
    }
}