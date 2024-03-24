using Code.UI.StatsInformation;

namespace Code.StateMachine.States
{
    public class StatsInformationState : IState
    {
        private readonly StatsOverlay _statsOverlay;

        public StatsInformationState(StatsOverlay statsOverlay)
        {
            _statsOverlay = statsOverlay;
        }
        public void Enter()
        {
            _statsOverlay.Show();
        }

        public void Exit()
        {
            _statsOverlay.Hide();
        }
    }
}