using System;
using System.Collections.Generic;
using Code.Services.SaveLoadDataService;
using Code.Services.StaticDataService.Configs;

namespace Code.Services.ShopService
{
    public interface IShopService : ILoadable, ISavable
    {
        IReadOnlyDictionary<IItemConfig, bool> Items { get; }
        event Action Updated;
        bool TryBuy(IItemConfig config);
    }
}