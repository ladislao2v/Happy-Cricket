using Code.Services.HealthService;
using Zenject;

namespace Code.Installers.Local
{
    public class HealthServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<HealthService>()
                .AsSingle();
        }
    }
}