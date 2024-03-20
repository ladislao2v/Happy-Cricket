using System;
using System.Collections.Generic;
using System.Linq;
using Code.Services.SaveLoadDataService;
using Code.Services.StaticDataService;
using Code.Services.StaticDataService.Configs;
using Code.Services.WalletService;

namespace Code.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly Dictionary<IItemConfig, bool> _items;
        private readonly IWalletService _walletService;
        public IReadOnlyDictionary<IItemConfig, bool> Items => _items;
        
        public event Action Updated;

        public ShopService(IStaticDataService staticDataService, IWalletService walletService)
        {
            _walletService = walletService;
            
            _items = 
                staticDataService
                    .GetShopItems()
                    .ToDictionary(x => x, x=> false);
        }

        public bool TryBuy(IItemConfig config)
        {
            if (_items.ContainsKey(config) == false)
                throw new ArgumentException(nameof(config));

            if (_items[config])
                return false;

            if (_walletService.TrySpend(config.Price) == false)
                return false;
            
            Updated?.Invoke();
            
            return true;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var items = saveLoadDataService
                .LoadByCustomKey<Dictionary<IItemConfig, bool>>(nameof(Items));

            foreach (var pair in items)
            {
                _items.Add(pair.Key, pair.Value);
            }
            
            Updated?.Invoke();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService) =>
            saveLoadDataService
                .SaveByCustomKey(_items, nameof(Items));
    }
}