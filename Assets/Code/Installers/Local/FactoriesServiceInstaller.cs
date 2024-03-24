using Code.Services.Factories.AchievementViewFactory;
using Code.Services.Factories.ShopItemViewFactory;
using Code.UI.Achievements;
using Code.UI.Shop;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class FactoriesServiceInstaller : MonoInstaller
    {
        [SerializeField] private ShopItemView _shopItemViewPrefab;
        [SerializeField] private AchievementView _achievementViewPrefab;
        
        public override void InstallBindings() => 
            BindFactory();

        private void BindFactory()
        {
            Container
                .BindInterfacesAndSelfTo<AchievementViewFactory>()
                .AsSingle()
                .WithArguments(_achievementViewPrefab);
                
            
            Container
                .BindInterfacesAndSelfTo<ShopItemViewFactory>()
                .AsSingle()
                .WithArguments(_shopItemViewPrefab);
        }
    }
}