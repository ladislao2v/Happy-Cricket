using Code.Services.HealthService;
using Code.Views.Ball;
using Zenject;

namespace Code.Triggers
{
    public class MissChallengeTrigger : Trigger<ChallengeBallView>
    {
        private IHealthService _healthService;

        [Inject]
        private void Construct(IHealthService healthService)
        {
            _healthService = healthService;
        }
        
        protected override void InteractWith(ChallengeBallView view)
        {
            _healthService.Receive();
            view.Return();
        }
    }
}