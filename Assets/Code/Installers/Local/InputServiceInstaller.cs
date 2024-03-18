using Code.Services.InputService;
using Zenject;

namespace Code.Installers.Local
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}