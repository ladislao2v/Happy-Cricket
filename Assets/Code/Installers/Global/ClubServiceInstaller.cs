using Code.Services.ClubService;
using Zenject;

namespace Code.Installers.Global
{
    public class ClubServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindService();

        private void BindService() =>
            Container
                .BindInterfacesAndSelfTo<ClubService>()
                .AsSingle();
    }
}