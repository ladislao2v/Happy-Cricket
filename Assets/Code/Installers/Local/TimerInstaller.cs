using Code.Services.TimerService;
using Zenject;

namespace Code.Installers.Local
{
    public class TimerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Timer>().AsSingle();
        }
    }
}