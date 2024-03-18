using Code.Services.StaticDataService;
using Zenject;

namespace Code.Installers.Global
{
    public class StaticDataInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindSceneLoader();

        private void BindSceneLoader() =>
            Container
                .BindInterfacesAndSelfTo<StaticDataService>()
                .AsSingle();
    }
}