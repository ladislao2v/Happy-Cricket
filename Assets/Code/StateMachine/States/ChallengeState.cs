using Code.UI.Challenge;
using UnityEditorInternal;
using UnityEngine.UIElements;

namespace Code.StateMachine.States
{
    public class ChallengeState : IState
    {
        private readonly ChallengeOverlay _challengeOverlay;

        public ChallengeState(ChallengeOverlay challengeOverlay)
        {
            _challengeOverlay = challengeOverlay;
        }
        
        public void Enter()
        {
            _challengeOverlay.Show();
        }

        public void Exit()
        {
            _challengeOverlay.Hide();
        }
    }
}