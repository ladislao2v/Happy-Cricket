using Code.Services.ScoreService;
using Code.Services.StatsService;
using Code.Services.WalletService;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Gamelose
{
    public class GameloseOverlay : Overlay
    {
        [SerializeField] private WalletView _walletView;
        [SerializeField] private RecordView _recordView;
        [SerializeField] private CustomButton _homeButton;
        [SerializeField] private GameObject _win;
        [SerializeField] private GameObject _lose;

        private IStateMachine _stateMachine;
        private IScoreService _scoreService;
        private IWalletService _walletService;
        private IStatsService _statsService;

        [Inject]
        private void Construct(IStateMachine stateMachine, IScoreService scoreService, IWalletService walletService,
        IStatsService statsService)
        {
            _statsService = statsService;
            _walletService = walletService;
            _scoreService = scoreService;
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _homeButton.Subscribe(OnRestartButtonClicked);
            _walletService.MoneyChanged += _walletView.OnMoneyChanged;
            _recordView.Render(_scoreService.Score);

            if (_scoreService.IsWin)
            {
                _win.SetActive(true);
                _walletService.Add(_scoreService.Score);
                Debug.Log("WIN!!!");
            }
            else
            {
                _lose.SetActive(true);
                Debug.Log("LOSE(((");
            }
            
            _statsService.AddMatchWin();
        }

        private void OnDisable()
        {
            _homeButton.Unsubscribe(OnRestartButtonClicked);
            _walletService.MoneyChanged += _walletView.OnMoneyChanged;
        }

        private void OnRestartButtonClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}