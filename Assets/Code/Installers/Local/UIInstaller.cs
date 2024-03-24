using Code.UI.Achievements;
using Code.UI.Challenge;
using Code.UI.ClubCreation;
using Code.UI.DailyReward;
using Code.UI.Gamelose;
using Code.UI.Gameplay;
using Code.UI.Menu;
using Code.UI.Settings;
using Code.UI.Shop;
using Code.UI.StatsInformation;
using Code.UI.Timer;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private MenuOverlay _menu;
        [SerializeField] private GameplayOverlay _gameplayOverlay;
        [SerializeField] private GameloseOverlay _gameloseOverlay;
        [SerializeField] private ShopOverlay _shopOverlay;
        [SerializeField] private SettingsOverlay _settingsOverlay;
        [SerializeField] private StatsOverlay _statsOverlay;
        [SerializeField] private AchievementsOverlay _achievementsOverlay;
        [SerializeField] private ClubCreationOverlay _clubCreationOverlay;
        [SerializeField] private DailyRewardsOverlay _dailyRewardOverlay;
        [SerializeField] private TimerOverlay _timerOverlay;
        [SerializeField] private ChallengeOverlay _challengeOverlay;

        public override void InstallBindings()
        {
            BindMenu();
            BindGameplayOverlay();
            BindGameloseOverlay();
            BindAchievementsOverlay();
            BindSettingsOverlay();
            BindShopOverlay();
            BindStatsOverlay();
            BindDailyRewardOverlay();
            BindClubCreationOverlay();
            BindTimerOverlay();
            BindChallengeOverlay();
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
        
        private void BindSettingsOverlay() =>
            Container
                .Bind<SettingsOverlay>()
                .FromInstance(_settingsOverlay)
                .AsSingle();
        
        private void BindStatsOverlay() =>
            Container
                .Bind<StatsOverlay>()
                .FromInstance(_statsOverlay)
                .AsSingle();
        
        private void BindShopOverlay() =>
            Container
                .Bind<ShopOverlay>()
                .FromInstance(_shopOverlay)
                .AsSingle();
        
        private void BindClubCreationOverlay() =>
            Container
                .Bind<ClubCreationOverlay>()
                .FromInstance(_clubCreationOverlay)
                .AsSingle();
        
        private void BindAchievementsOverlay() =>
            Container
                .Bind<AchievementsOverlay>()
                .FromInstance(_achievementsOverlay)
                .AsSingle();
        
        private void BindDailyRewardOverlay() =>
            Container
                .Bind<DailyRewardsOverlay>()
                .FromInstance(_dailyRewardOverlay)
                .AsSingle();
        
        private void BindTimerOverlay() =>
            Container
                .Bind<TimerOverlay>()
                .FromInstance(_timerOverlay)
                .AsSingle();
        
        private void BindChallengeOverlay() =>
            Container
                .Bind<ChallengeOverlay>()
                .FromInstance(_challengeOverlay)
                .AsSingle();
    }
}