using Code.Services.InputService;
using Code.StateMachine.States;
using Code.Views.Players;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private StrikerView _strikerView;
        [SerializeField] private PitcherView _pitcherView;
        public override void InstallBindings()
        {
            Container.Bind<StrikerView>().FromInstance(_strikerView).AsSingle();
            Container.Bind<PitcherView>().FromInstance(_pitcherView).AsSingle();
        }
    }
}