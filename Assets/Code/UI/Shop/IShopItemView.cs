using System;
using Code.Services.StaticDataService.Configs;
using UnityEngine;

namespace Code.UI.Shop
{
    public interface IShopItemView
    {
        IItemConfig Config { get; }
        event Action<IShopItemView> BuyButtonClicked;
        event Action<GameObject> DressButtonClicked;
        void Construct(IItemConfig config, bool isLock);
        void MakeActive();
        void MakePassive();
    }
}