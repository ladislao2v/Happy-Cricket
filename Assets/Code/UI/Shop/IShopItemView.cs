using System;
using Code.Services.StaticDataService.Configs;
using UnityEngine;

namespace Code.UI.Shop
{
    public interface IShopItemView
    {
        IItemConfig Config { get; }
        event Action<IShopItemView> BuyButtonClicked;
        event Action<IItemConfig> DressButtonClicked;
        void Construct(IItemConfig config, bool isOpen);
        void MakeActive();
        void MakePassive();
    }
}