using Code.Services.StatsService;
using Zenject;

namespace Code.Installers.Global
{
    public class StatsServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindStatsService();

        private void BindStatsService() =>
            Container
                .BindInterfacesAndSelfTo<StatsService>()
                .AsSingle();
    }
}