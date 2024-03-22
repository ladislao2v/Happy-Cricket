using Code.Services.SkinService;
using Zenject;

namespace Code.Installers.Local
{
    public class SkinServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SkinService>()
                .AsSingle();
        }
    }
}