using System;
using Code.Services.StaticDataService.Configs;
using UnityEngine;

namespace Code.UI.Shop
{
    public interface IShopItemView
    {
        ItemConfig Config { get; }
        event Action<IShopItemView> BuyButtonClicked;
        event Action<ItemConfig> DressButtonClicked;
        void Construct(ItemConfig config, bool isOpen);
        void MakeActive();
        void MakePassive();
    }
}