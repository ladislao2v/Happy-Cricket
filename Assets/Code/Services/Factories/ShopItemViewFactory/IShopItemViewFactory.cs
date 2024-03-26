using Code.Services.StaticDataService.Configs;
using Code.UI.Shop;
using UnityEngine;

namespace Code.Services.Factories.ShopItemViewFactory
{
    public interface IShopItemViewFactory
    {
        IShopItemView Create(ItemConfig config, bool isLock, Transform container);
    }
}