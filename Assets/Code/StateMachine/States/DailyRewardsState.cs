using Code.Services.DailyRewardService;
using Code.UI.DailyReward;

namespace Code.StateMachine.States
{
    public class DailyRewardsState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IDailyRewardService _dailyRewardService;
        private readonly DailyRewardsOverlay _dailyRewardsOverlay;

        public DailyRewardsState(IStateMachine stateMachine, IDailyRewardService dailyRewardService, 
            DailyRewardsOverlay dailyRewardsOverlay)
        {
            _stateMachine = stateMachine;
            _dailyRewardService = dailyRewardService;
            _dailyRewardsOverlay = dailyRewardsOverlay;
        }
        public void Enter()
        {
            if(_dailyRewardService.CanGiveBonus)
                _dailyRewardsOverlay.Show();
            else
                _stateMachine.Enter<MenuState>();
        }

        public void Exit()
        {
            _dailyRewardsOverlay.Hide();
        }
    }
}