using Code.UI.ClubInformation;

namespace Code.StateMachine.States
{
    public class ClubInformationState : IState
    {
        private readonly ClubInformationOverlay _clubInformationOverlay;

        public ClubInformationState(ClubInformationOverlay clubInformationOverlay)
        {
            _clubInformationOverlay = clubInformationOverlay;
        }
        public void Enter()
        {
            _clubInformationOverlay.Show();
        }

        public void Exit()
        {
            _clubInformationOverlay.Hide();
        }
    }
}