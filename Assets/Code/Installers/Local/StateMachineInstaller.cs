using Code.Factories.StateFactory;
using Code.StateMachine;
using Zenject;

namespace Code.Installers.Local
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateFactory();
            BindStateMachine();
        }

        private void BindStateMachine() =>
            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle();

        private void BindStateFactory() =>
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle();
    }
}