using Code.Services.ClubService;
using Code.Services.DailyRewardService;
using Code.Services.GameDataService;
using Code.Services.InputService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Services.ShopService;
using Code.Services.SkinService;
using Code.Services.StatsService;
using Code.Services.TimerService;
using Code.Services.WalletService;

namespace Code.StateMachine.States
{
    public class InitialState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly IPauseService _pauseService;
        private readonly IScoreService _scoreService;
        private readonly IWalletService _walletService;
        private readonly IInputService _inputService;
        private readonly IStatsService _statsService;
        private readonly IClubService _clubService;
        private readonly ISkinService _skinService;
        private readonly IDailyRewardService _dailyRewardService;
        private readonly IShopService _shopService;
        private readonly ITimer _timer;

        public InitialState(IStateMachine stateMachine,
            IGameDataService gameDataService, 
            IPauseService pauseService,
            IScoreService scoreService,
            IWalletService walletService,
            IInputService inputService,
            IStatsService statsService,
            IClubService clubService,
            ISkinService skinService,
            IDailyRewardService dailyRewardService,
            IShopService shopService,
            ITimer timer)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _pauseService = pauseService;
            _scoreService = scoreService;
            _walletService = walletService;
            _inputService = inputService;
            _statsService = statsService;
            _clubService = clubService;
            _skinService = skinService;
            _dailyRewardService = dailyRewardService;
            _shopService = shopService;
            _timer = timer;
        }

        public void Enter()
        {
            InitializeGameDataService();
            InitializePauseService();

            _stateMachine.Enter<LoadDataState>();
        }

        private void InitializeGameDataService()
        {
            _gameDataService.Add(_statsService);
            _gameDataService.Add(_walletService);
            _gameDataService.Add(_clubService);
            _gameDataService.Add(_skinService);
            _gameDataService.Add(_scoreService);
            _gameDataService.Add(_shopService);
            _gameDataService.Add(_dailyRewardService);
        }

        private void InitializePauseService()
        {
            _pauseService.Add(_inputService);
            _pauseService.Add(_timer);
        }


        public void Exit() { }
    }
}