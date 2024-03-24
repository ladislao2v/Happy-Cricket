using System;
using Code.Services.DailyRewardService;
using Code.Services.WalletService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.UI.DailyReward
{
    public class DailyRewardsOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private BonusView[] _bonusViews;
        [SerializeField] private CustomButton _backButton;
        
        private IStateMachine _stateMachine;
        private IDailyRewardService _dailyRewardService;
        private IWalletService _walletService;

        [Inject]
        private void Construct(IStateMachine stateMachine, 
            IDailyRewardService dailyRewardService, IWalletService walletService)
        {
            _walletService = walletService;
            _dailyRewardService = dailyRewardService;
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            foreach (BonusView view in _bonusViews)
                view.MakeDisactive();
            
            if (TryGetBonus() == false) 
                return;

            _backButton.Subscribe(OnBackButtonClicked);
        }

        private bool TryGetBonus()
        {
            if (_dailyRewardService.CurrentDay > _bonusViews.Length)
                return false;

            for (int i = 0; i < _dailyRewardService.CurrentDay; i++)
                _bonusViews[i].MakeActive();

            var bonusView = _bonusViews[_dailyRewardService.CurrentDay - 1];

            _walletService.Add(bonusView.Bonus);
            _dailyRewardService.Take();
            return true;
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