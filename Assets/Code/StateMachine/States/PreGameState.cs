using Code.Services.TimerService;
using Code.UI.Timer;

namespace Code.StateMachine.States
{
    public class PreGameState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ITimer _timer;
        private readonly TimerOverlay _timerOverlay;
        private readonly int _time = 3;

        public PreGameState(IStateMachine stateMachine, ITimer timer, TimerOverlay timerOverlay)
        {
            _stateMachine = stateMachine;
            _timer = timer;
            _timerOverlay = timerOverlay;
        }
        public void Enter()
        {
            _timerOverlay.Show();
            _timer.TimeOut += OnTimeOut;
            _timerOverlay.Ready += OnReady;
            
        }

        public void Exit()
        {
            _timerOverlay.Hide();
            _timer.TimeOut -= OnTimeOut;
            _timerOverlay.Ready -= OnReady;
        }

        private void OnReady()
        {
            _timer.Start(_time);
        }

        private void OnTimeOut()
        {
            _stateMachine.Enter<PitcherThrowState>();
        }
    }
}