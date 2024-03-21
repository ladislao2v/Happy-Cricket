using Code.Services.WalletService;
using Zenject;

namespace Code.Installers.Global
{
    public class WalletServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindWalletService();

        private void BindWalletService() =>
            Container
                .BindInterfacesAndSelfTo<WalletService>()
                .AsSingle();
    }
}