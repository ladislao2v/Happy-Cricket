using Code.Services.PauseService;
using Zenject;

namespace Code.Installers.Global
{
    public class PauseServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindPauseService();

        private void BindPauseService() =>
            Container
                .BindInterfacesAndSelfTo<PauseService>()
                .AsSingle();
    }
}