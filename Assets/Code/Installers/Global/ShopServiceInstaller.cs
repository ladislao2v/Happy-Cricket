using Code.Services.ShopService;
using Zenject;

namespace Code.Installers.Global
{
    public class ShopServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindShopService();

        private void BindShopService() =>
            Container
                .BindInterfacesAndSelfTo<ShopService>()
                .AsSingle();
    }
}