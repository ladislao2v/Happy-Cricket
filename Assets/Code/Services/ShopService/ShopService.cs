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
        private readonly IWalletService _walletService;
        
        private Dictionary<IItemConfig, bool> _items;
        public IReadOnlyDictionary<IItemConfig, bool> Items => _items;
        
        public event Action Updated;

        public ShopService(IStaticDataService staticDataService, IWalletService walletService)
        {
            _walletService = walletService;
            
            var shopItems = staticDataService.GetShopItems();

            var sortedShopItems = 
                shopItems.OrderBy(x => x.Price);
            
            _items = 
               sortedShopItems
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

            _items[config] = true;
            
            Updated?.Invoke();
            
            return true;
        }

        public void LoadData(ISaveLoadDataService saveLoadDataService)
        {
            var items = saveLoadDataService
                .LoadByCustomKey<Dictionary<IItemConfig, bool>>(nameof(Items));

            _items = items;

            Updated?.Invoke();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService) =>
            saveLoadDataService
                .SaveByCustomKey(_items, nameof(Items));
    }
}