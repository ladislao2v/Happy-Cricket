using Code.Services.GameDataService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
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
        private readonly ITimer _timer;

        public InitialState(IStateMachine stateMachine,
            IGameDataService gameDataService, 
            IPauseService pauseService,
            IScoreService scoreService,
            IWalletService walletService,
            ITimer timer)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _pauseService = pauseService;
            _scoreService = scoreService;
            _walletService = walletService;
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
            _gameDataService.Add(_walletService);
            _gameDataService.Add(_scoreService);
        }

        private void InitializePauseService()
        {
            _pauseService.Add(_timer);
        }


        public void Exit() { }
    }
}