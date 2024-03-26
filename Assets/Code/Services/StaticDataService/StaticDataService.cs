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
        
        private readonly List<ItemConfig> _shopItemsConfigs;
        private readonly List<AchievementConfig> _achievementsConfigs;

        public StaticDataService()
        {
            _shopItemsConfigs = Resources
                .LoadAll<ItemConfig>(ShopItemsPath)
                .ToList();
            _achievementsConfigs = Resources
                .LoadAll<AchievementConfig>(AchievementsPath)
                .ToList();
        }

        public ItemConfig[] GetShopItems() => 
            _shopItemsConfigs.ToArray();

        public AchievementConfig[] GetAchievements() => 
            _achievementsConfigs.ToArray();
    }
}