using Code.Services.ClubService;
using Code.Services.DailyRewardService;
using Code.Services.GameDataService;
using Code.Services.ScoreService;

namespace Code.StateMachine.States
{
    public sealed class LoadDataState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly IClubService _clubService;
        private readonly IDailyRewardService _dailyRewardService;

        public LoadDataState(IStateMachine stateMachine, 
            IGameDataService gameDataService, IClubService clubService, IDailyRewardService dailyRewardService)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _clubService = clubService;
            _dailyRewardService = dailyRewardService;
        }

        public void Enter()
        {
            _gameDataService.LoadData();
            _dailyRewardService.SyncTime();
            
            if(_clubService.IsCreated)
            {
                _stateMachine.Enter<DailyRewardsState>();
            }
            else
            {
                _stateMachine.Enter<ClubCreateState>();
            }
        }

        public void Exit() { }
    }
}