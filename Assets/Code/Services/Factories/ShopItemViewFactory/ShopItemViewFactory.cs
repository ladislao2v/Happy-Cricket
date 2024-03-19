using Code.Services.StaticDataService.Configs;
using Code.UI.Shop;
using UnityEngine;

namespace Code.Services.Factories.ShopItemViewFactory
{
    public class ShopItemViewFactory : IShopItemViewFactory
    {
        private readonly ShopItemView _prefab;

        public ShopItemViewFactory(ShopItemView prefab)
        {
            _prefab = prefab;
        }

        public IShopItemView Create(IItemConfig config, bool isLock, Transform container)
        {
            var view = Object.Instantiate<ShopItemView>(_prefab, container);
            
            view.Construct(config, isLock);
            view.transform.parent = container;

            return view;
        }
    }
}