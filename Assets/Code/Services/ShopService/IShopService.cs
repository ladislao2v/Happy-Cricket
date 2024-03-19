using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Code.Services.StaticDataService;
using Code.Services.StaticDataService.Configs;

namespace Code.Services.ShopService
{
    public interface IShopService
    {
        IReadOnlyDictionary<IItemConfig, bool> Items { get; }
        event Action Updated;
        bool TryBuy(IItemConfig config);
    }

    public class ShopService : IShopService
    {
        private readonly Dictionary<IItemConfig, bool> _items;
        public IReadOnlyDictionary<IItemConfig, bool> Items => _items;
        
        public event Action Updated;

        public ShopService(IStaticDataService staticDataService)
        {
            _items = 
                staticDataService
                .GetShopItems()
                .ToDictionary(x => x, x=> false);
        }

        public bool TryBuy(IItemConfig config)
        {
            throw new System.NotImplementedException();
        }
    }
}