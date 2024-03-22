using Code.Services.DailyRewardService;
using Code.Services.Factories.AchievementViewFactory;
using Code.Services.Factories.ShopItemViewFactory;
using Code.UI.Achievements;
using Code.UI.Shop;
using UnityEngine;
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
                .FromInstance(_achievementViewPrefab)
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<ShopItemViewFactory>()
                .FromInstance(_shopItemViewPrefab)
                .AsSingle();
        }
    }
}