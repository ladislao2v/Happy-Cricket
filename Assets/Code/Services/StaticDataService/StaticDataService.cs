using System;
using System.Collections.Generic;
using System.Linq;
using Code.Services.ShopService;
using Code.Services.StaticDataService.Configs;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string ChampionshipsPath = "ShopItems";
        
        private readonly List<IItemConfig> _configs;

        public StaticDataService() =>
            _configs = Resources
                .LoadAll<ItemConfig>(ChampionshipsPath)
                .Cast<IItemConfig>()
                .ToList();

        public IItemConfig[] GetShopItems()
        {
            return _configs.ToArray();
        }
    }
}