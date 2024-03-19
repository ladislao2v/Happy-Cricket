using System;
using Code.Services.StaticDataService.Configs;

namespace Code.UI.Shop
{
    public interface IShopItemView
    {
        event Action<IItemConfig> Clicked;
        void Construct(IItemConfig config, bool isLock);
    }
}