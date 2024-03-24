using Code.StateMachine;
using Code.StateMachine.States;
using Code.Services.ScoreService;
using Code.Services.WalletService;
using UnityEngine;
using Zenject;

namespace Code.UI.Menu
{
    public class MenuOverlay : Overlay
    {
        [SerializeField] private RecordView _recordView;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private CustomButton _playButton;
        [SerializeField] private CustomButton _challengeButton;
        [SerializeField] private CustomButton _statsButton;
        [SerializeField] private CustomButton _shopButton;
        [SerializeField] private CustomButton _achievementsButton;
        [SerializeField] private CustomButton _myClubButton;
        [SerializeField] private CustomButton _settingsButton;

        private IStateMachine _stateMachine;
        private IScoreService _scoreService;
        private IWalletService _walletService;

        [Inject]
        private void Construct(IStateMachine stateMachine, IScoreService scoreService, IWalletService walletService)
        {
            _walletService = walletService;
            _scoreService = scoreService;
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _playButton.Subscribe(OnPlayClicked);
            _challengeButton.Subscribe(OnChallengeClicked);
            _statsButton.Subscribe(OnStatsClicked);
            _shopButton.Subscribe(OnShopClicked);
            _achievementsButton.Subscribe(OnAchievementsClicked);
            _myClubButton.Subscribe(OnMyClubClicked);
            _settingsButton.Subscribe(OnSettingsClicked);
            _walletService.MoneyChanged += _walletView.OnMoneyChanged;
            
            _recordView.Render(_scoreService.Record);
            _walletView.OnMoneyChanged(_walletService.Value);
        }

        private void OnDisable()
        {
            _playButton.Unsubscribe(OnPlayClicked);
            _challengeButton.Unsubscribe(OnChallengeClicked);
            _statsButton.Unsubscribe(OnStatsClicked);
            _shopButton.Unsubscribe(OnShopClicked);
            _achievementsButton.Unsubscribe(OnAchievementsClicked);
            _myClubButton.Unsubscribe(OnMyClubClicked);
            _settingsButton.Unsubscribe(OnSettingsClicked);
            _walletService.MoneyChanged -= _walletView.OnMoneyChanged;
        }

        private void OnSettingsClicked()
        {
            _stateMachine.Enter<SettingsState>();
        }

        private void OnMyClubClicked()
        {
            _stateMachine.Enter<ClubCreateState>();
        }

        private void OnAchievementsClicked()
        {
            _stateMachine.Enter<AchievementsState>();
        }

        private void OnShopClicked()
        {
            _stateMachine.Enter<ShopState>();
        }

        private void OnStatsClicked()
        {
            _stateMachine.Enter<StatsInformationState>();
        }

        private void OnChallengeClicked()
        {
            _stateMachine.Enter<ChallengeState>();
        }

        private void OnPlayClicked()
        {
            _stateMachine.Enter<PreGameState>();
        }
    }
}