using Code.Services.ScoreService;
using Code.UI.Challenge;

namespace Code.StateMachine.States
{
    public class ChallengeState : IState
    {
        private readonly ChallengeOverlay _challengeOverlay;
        private readonly IScoreService _scoreService;

        public ChallengeState(ChallengeOverlay challengeOverlay, IScoreService scoreService)
        {
            _challengeOverlay = challengeOverlay;
            _scoreService = scoreService;
        }
        
        public void Enter()
        {
            _scoreService.Reset();
            _challengeOverlay.Show();
        }

        public void Exit()
        {
            _challengeOverlay.Hide();
        }
    }
}