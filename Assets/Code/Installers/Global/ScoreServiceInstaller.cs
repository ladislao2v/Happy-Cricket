using Code.Services.ScoreService;
using Zenject;

namespace Code.Installers.Global
{
    public class ScoreServiceInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindScoreService();

        private void BindScoreService() =>
            Container
                .BindInterfacesAndSelfTo<ScoreService>()
                .AsSingle();
    }
}
