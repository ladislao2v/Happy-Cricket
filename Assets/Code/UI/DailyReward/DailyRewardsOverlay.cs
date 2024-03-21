using System;
using UnityEngine;

namespace Code.UI.DailyReward
{
    public class DailyRewardsOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private CustomButton _backButton;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            _backButton.Unsubscribe(OnBackButtonClicked);
        }

        public void OnBackButtonClicked()
        {
            
        }
    }
}