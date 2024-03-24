using Code.Services.DailyRewardService;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Installers.Global
{
    public class DailyRewardServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            BindService();

        private void BindService() =>
            Container
                .BindInterfacesAndSelfTo<DailyRewardService>()
                .AsSingle();
    }
}