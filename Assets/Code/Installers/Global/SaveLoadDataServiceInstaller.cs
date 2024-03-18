using Code.Services.SaveLoadDataService;
using Zenject;

namespace Code.Installers.Global
{
    public class SaveLoadDataServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindSaveLoadDataService();

        private void BindSaveLoadDataService() =>
            Container
                .BindInterfacesAndSelfTo<SaveLoadDataService>()
                .AsSingle();
    }
}