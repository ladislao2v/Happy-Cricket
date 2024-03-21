using System;
using System.Collections.Generic;
using System.Linq;
using Code.Services.AchievementsService;
using Code.Services.ShopService;
using Code.Services.StaticDataService.Configs;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string ShopItemsPath = "ShopItems";
        private const string AchievementsPath = "Achievements";
        
        private readonly List<IItemConfig> _shopItemsConfigs;
        private readonly List<IAchievementConfig> _achievementsConfigs;

        public StaticDataService()
        {
            _shopItemsConfigs = Resources
                .LoadAll<ItemConfig>(ShopItemsPath)
                .Cast<IItemConfig>()
                .ToList();
            _achievementsConfigs = Resources
                .LoadAll<AchievementConfig>(AchievementsPath)
                .Cast<IAchievementConfig>()
                .ToList();
        }

        public IItemConfig[] GetShopItems() => 
            _shopItemsConfigs.ToArray();

        public IAchievementConfig[] GetAchievements() => 
            _achievementsConfigs.ToArray();
    }
}