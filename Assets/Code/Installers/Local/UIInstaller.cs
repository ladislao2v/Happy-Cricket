using Code.StateMachine.States;
using Code.UI.Gamelose;
using Code.UI.Gameplay;
using Code.UI.Menu;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private MenuOverlay _menu;
        [SerializeField] private GameplayOverlay _gameplayOverlay;
        [SerializeField] private GameloseOverlay _gameloseOverlay;

        public override void InstallBindings()
        {
            BindMenu();
            BindGameplayOverlay();
            BindGameloseOverlay();
        }

        private void BindGameloseOverlay()=>
            Container
                .Bind<GameloseOverlay>()
                .FromInstance(_gameloseOverlay)
                .AsSingle();

        private void BindMenu() =>
            Container
                .Bind<MenuOverlay>()
                .FromInstance(_menu)
                .AsSingle();

        private void BindGameplayOverlay() =>
            Container
                .Bind<GameplayOverlay>()
                .FromInstance(_gameplayOverlay)
                .AsSingle();
    }
}