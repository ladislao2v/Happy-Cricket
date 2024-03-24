using System;
using Code.Services.WalletService;
using UnityEngine;
using Zenject;

namespace Code.UI.Gameplay
{
    public class HalfView : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;
        [SerializeField] private CustomButton _continueButton;
        private IWalletService _walletService;

        public CustomButton ContinueButton => _continueButton;

        [Inject]
        private void Construct(IWalletService walletService)
        {
            _walletService = walletService;
        }

        private void OnEnable()
        {
            _walletView.OnMoneyChanged(_walletService.Value);
        }
    }
}