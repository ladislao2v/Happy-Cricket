using Code.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Code.Installers.GlobalInstallers
{
    public class CoroutineRunnerInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _runner;
        public override void InstallBindings() => BindCoroutineRunner();

        private void BindCoroutineRunner() => 
            Container
                .BindInterfacesAndSelfTo<CoroutineRunner>()
                .FromInstance(_runner)
                .AsSingle()
                .NonLazy();
    }
}