using Code.UI.Achievements;

namespace Code.StateMachine.States
{
    public class AchievementsState : IState
    {
        private readonly AchievementsOverlay _achievementsOverlay;

        public AchievementsState(AchievementsOverlay achievementsOverlay)
        {
            _achievementsOverlay = achievementsOverlay;
        }
        
        public void Enter()
        {
            _achievementsOverlay.Show();
        }

        public void Exit()
        {
            _achievementsOverlay.Hide();
        }
    }
}