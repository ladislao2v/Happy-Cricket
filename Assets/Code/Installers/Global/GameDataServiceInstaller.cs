using Code.Services.GameDataService;
using Zenject;

namespace Code.Installers.GlobalInstallers
{
    public class GameDataServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindGameDataService();

        private void BindGameDataService() =>
            Container
                .BindInterfacesAndSelfTo<GameDataService>()
                .AsSingle();
    }
}