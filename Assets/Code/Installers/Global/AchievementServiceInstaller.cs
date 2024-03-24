using Code.Services.AchievementsService;
using Zenject;

namespace Code.Installers.Global
{
    public class AchievementServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindService();

        private void BindService() =>
            Container
                .BindInterfacesAndSelfTo<AchievementsService>()
                .AsSingle()
                .NonLazy();
    }
}