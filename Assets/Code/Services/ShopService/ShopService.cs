using System;
using System.Collections.Generic;
using System.Linq;
using Code.Services.SaveLoadDataService;
using Code.Services.StaticDataService;
using Code.Services.StaticDataService.Configs;
using Code.Services.WalletService;
using UnityEngine;

namespace Code.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly IWalletService _walletService;
        
        private Dictionary<ItemConfig, bool> _items;
        public IReadOnlyDictionary<ItemConfig, bool> Items => _items;
        
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
            
            Debug.Log(nameof(_items) + _items.Count);
        }

        public bool TryBuy(ItemConfig config)
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
            var values = saveLoadDataService
                .Load<bool[]>();
            
            if(values == null)
                return;
            
            if(values.Length == 0)
                return;
            
            var keys = _items.Keys.ToArray();
            for(int i = 0; i < _items.Count; i++)
            {
                _items[keys[i]] = values[i];
            }

            Updated?.Invoke();
        }

        public void SaveData(ISaveLoadDataService saveLoadDataService) =>
            saveLoadDataService
                .Save(_items.Values.ToArray());
    }
}